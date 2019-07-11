using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHitsZone : MonoBehaviour
{
    public bool isDamaging; // Is it damaging? False.
    public int damage = 5;
    public Player player;

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (isDamaging)
            {            
                player.currentHealth = (int)(player.currentHealth - (damage * Time.deltaTime));
            }
            UIEventHandler.HealthChanged(this.player.currentHealth, this.player.currentHealth);
        }
    }
}
