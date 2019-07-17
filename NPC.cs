using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string _name;

    public override void Interact()
    {
        // Debug.Log("NPC interacted with. Succeed.");
        DialogueSystem.Instance.AddNewDialogue(dialogue, _name);    
    }
}
