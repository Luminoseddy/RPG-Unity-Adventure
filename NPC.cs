using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string _name;

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, _name);
        Debug.Log("Interacted with NPC from NPC class.");
    }
}
