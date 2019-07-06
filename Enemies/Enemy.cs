using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    // ============================================================================================================================================
    // Health Bar Functionality
    // ============================================================================================================================================
    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    // Set current health to max health
    private void OnEnable() { currentHealth = maxHealth; }
   
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }
    // ============================================================================================================================================
     

    private void Update() { } 

    // We want this to be used in other instances
    public virtual void Hit () {
        // currentHealth--;

        if (currentHealth <= 0) {
             Destroy(gameObject); 
        }
    }

    public void OnTriggerEnter(Collider otherCollider)
    {     
        if (otherCollider.GetComponent<Sword>() != null){
            if (otherCollider.GetComponent<Sword>().IsAttacking) { // Make sure its being attacked: True for enemy to take a hit.. Must swing sword for enemy to take hit
                ModifyHealth(-10);
                Hit();
            }
        }else if (otherCollider.GetComponent<Arrow>()!= null){
            ModifyHealth(-10);
            Hit();
            Destroy(otherCollider.gameObject);
        }else if (otherCollider.GetComponent<Bullet>() != null) {
            ModifyHealth(-10);
            Hit();
            Destroy(otherCollider.gameObject);
        }
    }

    // ============================================================================================================================================
    // Experience Bar Functionality
    // ============================================================================================================================================



    // ============================================================================================================================================

} 
