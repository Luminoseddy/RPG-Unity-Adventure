using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelly : MonoBehaviour, XEnemy
{
    public float currentHealth;
    public float power, toughness;
    public float maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
     
    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
