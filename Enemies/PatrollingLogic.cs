using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingLogic : MonoBehaviour
{

    // Every gameObject we use this in must have a rigidbody
    // We need it because we're gonna be dealing with velocity directly from the gameObject
    // we're working with.
    public Vector3[] directions;    // An array of directions, Where the enemy will be walking to.
    public float timeToChange = 1f; // time to change directopn
    public float movementSpeed;     // How fast the enemy moves.

    private int directionPointer; // Points the direction we're currently at
    private float directionTimer; // timer used beofre direction is changed. 


    void Start(){
        directionPointer = 0;
        directionTimer = timeToChange;
    }

    // Update is called once per frame
    void Update(){
        // Changing directions.
        directionTimer -= Time.deltaTime;
        if(directionTimer <= 0f){
            directionTimer = timeToChange;   
            directionPointer++;
            if (directionPointer >= directions.Length){
                directionPointer = 0;
            }
        }
        // Make the object move.
        GetComponent<Rigidbody>().velocity = new Vector3(
            directions[directionPointer].x * movementSpeed, // directions of that index.
            GetComponent<Rigidbody> ().velocity.y,          // Whatever the velocity/gravity is
            directions[directionPointer].z * movementSpeed  // Caues object to move whatever index is at from directionPointer
        );
    }
}
