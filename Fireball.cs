using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 spawnPosition;
    public  Vector3 Direction { get; set;  }
    public  float   Range     { get; set; }
    public  int     Damage    { get; set; }

    void Start()
    {
        Range = 20f;
        Damage = 4;
        spawnPosition = transform.position;

        /* Knudge the object the player is facing using the Direction vector which points the direction the player is facing.
         * and multiply it by a value to give it speed. */
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    /* How far away are you from where you started */
    void Update()
    {
        /* spawn position (place where we started at), current position (distance between the two vectors) */
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish(); /* If the cast is too far away, destory it. */ 
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Enemy")
        {           
            col.transform.GetComponent<IEnemy>().TakeDamage(Damage); 
        }    
        Extinguish(); /* If enemy or not enemy, it destorys itself. */
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }
}
