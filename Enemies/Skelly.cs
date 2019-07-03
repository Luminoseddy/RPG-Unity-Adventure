using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skelly : MonoBehaviour, IEnemy
{

    public LayerMask aggroLayerMask;

    private NavMeshAgent navAgent;
    public float attack, strength, currentHealth, maxHealth;
    private CharacterStats characterStats;
    private Collider[] withinAggroColliders;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(5, 10, 15);
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        /* Send out imaginated sphere that exist aroudn every frame around the enemy to
           decide if theres a collider its looking for inside the spehre or not.. Sphere == radius. */
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);


        if (withinAggroColliders.Length > 0)
        {
            Debug.Log("Player has been spotted");
        }
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
