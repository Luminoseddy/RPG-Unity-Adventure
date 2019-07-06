using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skelly : MonoBehaviour, IEnemy
{ 
    public  LayerMask      aggroLayerMask;

    private NavMeshAgent   navAgent;
    private CharacterStats characterStats;
    private Player         player;
    private Collider[]     withinAggroColliders;

    public float attack, strength, maxHealth, currentHealth;
    
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>(); // Reference from navagent on the enemy
        characterStats = new CharacterStats(5, 10, 15);
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        /* Send out imaginated sphere that exist aroudn every frame around the enemy to
           decide if theres a collider its looking for inside the spehre or not.. Sphere == radius.
           10 units for it to exist. */
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);

        if (withinAggroColliders.Length > 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
            // Debug.Log("Player has been spotted. Get em!!");
        }
    }
     
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Source: @17:20 https://www.youtube.com/watch?v=Bs0rJEkYBvc&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=16
    void ChasePlayer(Player player)
    {
        // Ensures the enemy can't attack unless close to you.
        navAgent.SetDestination(player.transform.position);
        this.player = player;  
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!IsInvoking("PerformAttack"))
            {
                // Invoke itself automatically, starting time attack is .5f.  when it gets close, then every 2 seconds hit.
                InvokeRepeating("PerformAttack", .5f, 1f);
            }   
        }
        else
        {
            // Debug.Log("Not within distance");
            CancelInvoke("PerformAttack");
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void PerformAttack()
    {
        player.TakeDamage(5); 
    }
}
