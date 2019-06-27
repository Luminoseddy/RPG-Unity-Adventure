﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// @22:00 https://www.youtube.com/watch?v=hyh3kKGvJQw

public class Fireball : MonoBehaviour
{
    public Vector3 Direction { get; set;  }
    public float Range  { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;

    private void Start()
    {
        Range = 20f;
        Damage = 4;

        spawnPosition = transform.position;

        // Knudge the object the player is facing
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    // How far away are you from where yous tarted
    void Update()
    {
        // spawn position, current position
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish(); // If the cast is too far away, destory it. 
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Enemy")
        {
            col.transform.GetComponent<XEnemy>().TakeDamage(Damage);
        }
        Extinguish(); // If enemy or not enemy, it destorys itself.
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }
}
