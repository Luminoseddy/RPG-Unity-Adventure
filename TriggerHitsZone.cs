using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHitsZone : MonoBehaviour
{
    public bool isDamaging; // Is it damaging? False.
    public float damage = 24.5f;
    public Player player;

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (isDamaging)
            {
                // Take away hitpoints
                // col.SendMessage("Taking Damage", Time.deltaTime * damage);
                player.health = player.health - (damage * Time.deltaTime);
            }       
        }
    }
}
