using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;

    private bool hasInteracted;

    public virtual void CheckPlayerAndPlayerAgentCollision(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        //this.playerAgent = playerAgent;
        //playerAgent.stoppingDistance = 3f;
        //playerAgent.destination = transform.position;
        Interact();
    }

    void Update()
    {
        // check for player agent
        if (!hasInteracted && playerAgent != null )
        {
            // Checks the distance between playerAgent and player.
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }

        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interaction using base class, complete.");
    }
}
