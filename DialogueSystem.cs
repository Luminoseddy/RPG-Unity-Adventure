using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [HideInInspector] public string npcName;

    /* Tells us which dialouge we're in, allows us to 'continue' */
    int dialogueIndex; 

    Button continueButton;

    /* */
    Text dialogueText, nameText;

    /* A property that allows us to create a static instance */
    public static DialogueSystem Instance { get; set; }

    /* Used this to reference the panel to grab the children of the panel given text, name */
    public GameObject dialoguePanel;

    public List<string> dialogueLines = new List<string>();

    void Awake()
    {
        /* The strings are the children of the dialogue panel. References to the UI */
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText   = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText       = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>(); // Get the 1st child of the child Name

        /* Event that happens when the buttonClick is pressed.
         * When onClick occurs, the event is added, and this event must be a delegate.
         * 
         * delegate is a reference type variable that holds the reference to a method.
         * The reference can be changed at runtime.
         */
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false); // Start with no dialogue in display.

        /* An Instance exist that is not this Instance -> destory. */
        /* Prevent multiple dialouge pop ups if talking to different NPC's at once. */
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            /* If the instance doesn't exist, then now exist, reference to THIS instance of this object. */
            Instance = this; 
        }
    }


    /* Takes in array of Strings*/
    public void AddNewDialogue(string [] lines, string npcName)
    {
        /* Start at index 0 when ever the dialogue is added. */
        dialogueIndex = 0; 

        /* Recreating an empty list */
        dialogueLines = new List<string>(lines.Length);

        /* Adds the text at the end of the list. */
        dialogueLines.AddRange(lines);

        this.npcName = npcName;
        // Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    /* Handles the enabling of the panel. */
    public void CreateDialogue()
    {
        /* Grab the dialougueText and its property text, with its first index */
        dialogueText.text = dialogueLines[dialogueIndex]; 
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    /* Increases the dialogue index, then showing new dialogues. */
    public void ContinueDialogue()
    {
        /* Comparing the index to the actual index of the amount of items we have. */
        if (dialogueIndex < dialogueLines.Count - 1) 
        {
            /* add to reach next index */
            dialogueIndex++;

            /* Then pass it to update the dialogue */
            dialogueText.text = dialogueLines[dialogueIndex]; 
        }
        else
        {
            /* Close the panel after all the dialogue / texts have been seen. */
            dialoguePanel.SetActive(false);
        }
    }
}
