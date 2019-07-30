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
        DialogueSystem.Instance.AddNewDialogue(dialogue, _name);    
    }
}
