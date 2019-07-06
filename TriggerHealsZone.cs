using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealsZone : MonoBehaviour 
{
    public bool isHealing; // Is it healing? False.
    public float heal = 10;
    public Player player;

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (isHealing)
            {
                // Increase hitpoints
                // col.SendMessage("Healing", Time.deltaTime * heal);
                player.health = player.health + (heal * Time.deltaTime);
            }
        }
    }
}
