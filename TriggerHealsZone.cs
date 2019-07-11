using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealsZone : MonoBehaviour 
{
    public bool isHealing; // Is it healing? False.
    public int heal = 10;
    public Player player;

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (isHealing)
            {
                player.currentHealth = (int)(player.currentHealth + (heal * Time.deltaTime));
            }
            UIEventHandler.HealthChanged(this.player.currentHealth, this.player.currentHealth);
        }
    }
}
