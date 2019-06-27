using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItem : Interactable
{
    /* The whole purpose of working this way is so that 
        * nothing break if you want to remove the pickUpitem funtionaility. */
    public override void Interact()
    {
        Debug.Log("ACTIONitem has been interacted with. hooray!");
        // base.Interact();
    }
}
