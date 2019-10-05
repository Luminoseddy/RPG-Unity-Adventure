using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector] public Rigidbody playerRigidbody;

    private bool hasInteracted,
                 isEnemy;

    /* Virtual methods are subclasses, extends interactable and methods within that can be overwritten.
     * Passed from WorldInteraction class. */
    public virtual void Interaction(Rigidbody playerRigidbody)
    {
        // hasInteracted = false;
        // this.playerRigidbody = playerRigidbody;
        //playerAgent.stoppingDistance = 3f;
        //playerAgent.destination = transform.position;
        Interact();
    }

    void Update()
    {
        // check for player agent
        //if (!hasInteracted && playerRigidbody != null )
        //{
        //    Interact();
        //    hasInteracted = true;
        //}
    }

    void EnsureLookDirection()
    {
        //playerAgent.updateRotation = false;
        //Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        //playerAgent.transform.LookAt(lookDirection);
        //playerAgent.updateRotation = true; 
    }

    public virtual void Interact() { Debug.Log("Interacted with bass class. Success."); }
    // private Vector3      GetTargetPosition() { return transform.position; }

}




