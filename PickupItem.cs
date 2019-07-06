using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{

    /* The whole purpose of working this way is so that 
     * nothing break if you want to remove the pickUpitem funtionaility. */
    public override void Interact()
    {
        Debug.Log("Interacted ITEM from pickupItem class.");
        // base.Interact();
    }
}
