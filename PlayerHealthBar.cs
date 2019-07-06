using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Source: 
// https://www.youtube.com/watch?v=9W0xLonwbLo

public class PlayerHealthBar : MonoBehaviour
{
    public float health = 100,
                 healthGainRate = 0.5f,
                 hunger = 100,
                 thirst = 100,
                 hungerRate,
                 thirstRate;

    public Slider healthBar,
                  hungerBar,
                  thirstBar;

    private void Update()
    {
        healthBar.value = health;
        //hungerBar.value = hunger;
        //thirstBar.value = thirst;

        //hunger = hunger - (hungerRate * Time.deltaTime);
        //thirst = thirst - (thirstRate * Time.deltaTime);
        health = health + (healthGainRate * Time.deltaTime); // 1 should be attackDamage
            
        if (health <= 0 || health >= 100)
        {
            health = 100;
        }

        //if (hunger <= 0 || thirst <= 0) 
        //{
        //    health = health - (deathRate * Time.deltaTime);
        //}

        //if (hunger <= 0)
        //{
        //    hunger = 0;
        //}

        //if (thirst <= 0)
        //{
        //    thirst = 0;
        //}
    }
}


