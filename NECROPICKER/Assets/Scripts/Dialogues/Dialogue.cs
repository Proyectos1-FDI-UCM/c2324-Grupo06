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

    ICondition condition;
   

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
        print(condition);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && condition.CheckCondition() && !didDialogueStart)
        {
            StartDialogue();
        }

         else   if (dialogueText.text == dialogueLines[currentDialogue] && condition.CheckCondition() && didDialogueStart)
        {
            
            NextDialogue();
        }
        
        
    }

    public void StartDialogue()
    {
        onDialogueStarts.Invoke();
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        DialogueMark.SetActive(false);
        currentDialogue = 0;
        StartCoroutine(ShowLine());
    }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<MovementController>() != null)
        {
            isPlayerInRange = true;
            DialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            isPlayerInRange = false;
            DialogueMark.SetActive(false);
        }
    }
}
