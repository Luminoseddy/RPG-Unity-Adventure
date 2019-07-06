using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter exitTeleporter;
    public float exitOffset = 2f;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider otherCollider){
        if (otherCollider.GetComponent<Player>() != null ){
            // To avoid errors.
            if (exitTeleporter != null){
                Player player = otherCollider.GetComponent<Player>(); // Player reference
                player.transform.position = exitTeleporter.transform.position + exitTeleporter.transform.forward * exitOffset;
            }
        }
    }

   
}
