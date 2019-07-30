using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [HideInInspector] public string npcName;
    int dialogueIndex; 

    Button continueButton;

    Text dialogueText,
         nameText;

    /* Allows us to create a static instance */
    public static DialogueSystem Instance { get; set; }

    /* Used this to reference the panel to grab the children of the panel */
    public GameObject dialoguePanel;

    
    public List<string> dialogueLines = new List<string>();

    void Awake()
    {
        /* The strings are the children of the dialogue panel. */
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText   = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText       = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>(); // Get the 1st child of the child Name

        /* Event that happens when the buttonClick is pressed.
         * When onClick occurs, the event is added, and the event must be a delegate.
         * 
         * delegate is a reference type variable that holds the reference to a method.
         * The reference can be changed at runtime.
         */
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);

        /* An Instance exist that is not this Instance -> destory. */
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            /* If the instance doesn't exist, now exist */
            Instance = this; 
        }
    }

 
    public void AddNewDialogue(string [] lines, string npcName)
    {
        
        dialogueIndex = 0; /* Start at index 0 when ever the dialogue is added. */

        /* More efficient than: - foreach (string line in lines){ dialogueLines.Add(line); }      
         * Recreating an empty list */
        dialogueLines = new List<string>(lines.Length);
        /* Adds the text at the end of the list. */
        dialogueLines.AddRange(lines);

        this.npcName = npcName;
        Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    /* Handles the enabling of the panel. */
    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex]; // Show the first text of that dialgue
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    /*  Increases the dialogue index, then showing new dialogues. */
    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1) // Comparing the index to the actual index of the amount of items we have.
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            // Close the panel after all the dialogue / texts have been seen.
            dialoguePanel.SetActive(false);
        }
    }
}
