using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [HideInInspector]
    public string npcName;

    public static DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;

    Button continueButton;
    Text dialogueText, 
         nameText;

    int dialogueIndex;
    public List<string> dialogueLines = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText   = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText       = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string [] lines, string npcName)
    {
        // Recreating using the constructor
        dialogueIndex = 0;

        // More efficient than: - foreach (string line in lines){ dialogueLines.Add(line); }
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        this.npcName = npcName;
        Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
