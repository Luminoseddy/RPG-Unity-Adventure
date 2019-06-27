using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// Source: https://www.youtube.com/watch?v=k-FVQ3jpRN8


public class WorldInteractions : MonoBehaviour
{

    public GameObject player;
    public GameObject npc;

    public float distance;

    [HideInInspector]
    public NavMeshAgent playerAgent;

    void Start()
    {
         playerAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Source to compare distance from npcObject
        // https://www.youtube.com/watch?v=OMPV-duv25Q

        distance = Vector3.Distance(player.transform.position, npc.transform.position);

        if (distance <= 5 && Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if(distance > 5)
            { 
                Debug.Log("You must get closer to speak with this NPC.");
            }
            else
            {
                GetInteractions();
            }
        }
    }

    void GetInteractions()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if (interactedObject.tag == "Interactable Object")
            {
                Debug.Log("Interactable Object Succes");
                interactedObject.GetComponent<Interactable>().CheckPlayerAndPlayerAgentCollision(playerAgent);
            }

            else
            {
                Debug.Log("Not clicking interactables..");
                 //playerAgent.stoppingDistance = 0;
                 //playerAgent.destination = interactionInfo.point;           
            }
        }
    }
}
