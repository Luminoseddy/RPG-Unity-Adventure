using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string _name;

    /* Best way would be creating json files per npc, keeping it b asic for now. */
    public override void Interact()
    {
        // Debug.Log("NPC interacted with. Succeed."); 
        /* Allows you to add custom dialouges and names to any NPC when script is attached to it. */
        DialogueSystem.Instance.AddNewDialogue(dialogue, _name);    
    }
}
// This way for simplicity. 
// Better way would be having dialogues in a JSON file that could be read from,
