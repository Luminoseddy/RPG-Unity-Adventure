using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;

    private bool hasInteracted, isEnemy;


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
                if (!isEnemy)
                {
                    Interact();
                }
                EnsureLookDirection();
                hasInteracted = true;
            }
        }
    }

    // SOURCE 5:00 https://www.youtube.com/watch?v=vGEkq9yNzxw&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=9
    void EnsureLookDirection()
    {
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updateRotation = true; 
    }

    public virtual void Interact()
    {
        Debug.Log("Interaction using base class, complete.");
    }
}
