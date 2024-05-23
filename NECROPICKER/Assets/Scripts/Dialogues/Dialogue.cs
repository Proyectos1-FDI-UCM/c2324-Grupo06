using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private MovementController player;

    [SerializeField] GameObject conditionContainer;

    [SerializeField] private GameObject dgconditioncontainer;

    ICondition condition;
    ICondition conditiondg;
   

    [SerializeField] private GameObject DialogueMark;
    private bool isPlayerInRange;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] Image _characterIcon;
    [SerializeField] SerializableDictionary<string, Sprite> characterIcons;
   

    [SerializeField] UnityEvent onDialogueStarts;
    [SerializeField] UnityEvent onDialogueEnds;
    

    private int currentDialogue = 0;
    private bool didDialogueStart;

    [SerializeField] float timeBetweenCharacters = 0.05f;

    private void Awake()
    {
        condition = conditionContainer.GetComponent<ICondition>();
        conditiondg = dgconditioncontainer.GetComponent<ICondition>();
       
    }

    // Si el jugador a�n no ha iniciado di�logo, est� en el rango para iniciarlo y cumple cierta condici�n, se inicia el di�logo
    void Update()
    {
        if (isPlayerInRange && condition.CheckCondition() && !didDialogueStart)
        {
            StartDialogue();
        }
    //Si pasa la condici�n y el di�logo ya ha empezado, contin�a con la siguiente l�nea de di�logo
         else   if (dialogueText.text == dialogueLines[currentDialogue] && conditiondg.CheckCondition() && didDialogueStart)
        {
            
            NextDialogue();
        }
        
        
    }
    //Settea todo para iniciar el di�logo
    public void StartDialogue()
    {
        onDialogueStarts.Invoke();
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        DialogueMark.SetActive(false);
        currentDialogue = 0;
        StartCoroutine(ShowLine());
    }
    //Determina si el di�logo finaliza o si contin�a, haciendo las modificaciones necesarias si se da el primer caso.
    public void NextDialogue()
    {
        currentDialogue++;
        if(currentDialogue < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            onDialogueEnds.Invoke();
            didDialogueStart = false;
            enabled = false;
            dialoguePanel.SetActive(false);
            DialogueMark.SetActive(true);
        }
    }
    //Determina qui�n est� diciendo el di�logo actual para cambiar de un sprite a otro y para cada l�nea de di�logo, las descompone en caracteres que se ir�n mostrando poco a poco
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        if(dialogueLines[currentDialogue].Contains(":"))
        {
            string[] parts = dialogueLines[currentDialogue].Split(':');
            _characterIcon.sprite = characterIcons[parts[0]];
            dialogueLines[currentDialogue] = parts[1];
        }

        foreach(char ch in dialogueLines[currentDialogue])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(timeBetweenCharacters);
        }
    }
    //Si el jugador est� en el rango, se mostrar� el indicador de que se puede iniciar di�logo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<MovementController>() != null)
        {
            isPlayerInRange = true;
            DialogueMark.SetActive(true);
        }
    }
    //Si el jugador sale del rango, desactiva el indicador
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            isPlayerInRange = false;
            DialogueMark.SetActive(false);
        }
    }
}
