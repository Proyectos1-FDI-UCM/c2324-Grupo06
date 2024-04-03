using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private MovementController player;
    [SerializeField] private GameObject DialogueMark;
    private bool isPlayerInRange;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    private int currentDialogue = 0;
    private bool didDialogueStart;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.X) && !didDialogueStart)
        {
            StartDialogue();
        }
        else if(dialogueText.text == dialogueLines[currentDialogue] && Input.GetKeyDown(KeyCode.X) && didDialogueStart)
        {
            NextDialogue();
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        DialogueMark.SetActive(false);
        currentDialogue = 0;
        StartCoroutine(ShowLine());
    }
    void NextDialogue()
    {
        currentDialogue++;
        if(currentDialogue < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            DialogueMark.SetActive(true);
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[currentDialogue])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<MovementController>() != null)
        {
            isPlayerInRange = true;
            DialogueMark.SetActive(true);
            Debug.Log("Se puede iniciar diálogo");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            isPlayerInRange = false;
            DialogueMark.SetActive(false);
            Debug.Log("No se puede iniciar diálogo");
        }
    }
}
