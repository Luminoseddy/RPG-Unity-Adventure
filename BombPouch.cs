using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPouch : MonoBehaviour
{
    public float throwingSpeed = 1.0f; // 175 in unity inspector

    public GameObject bombPrefab;
    public Transform bombSpawn;

    private AudioSource bombShotSound;

    public void Attack()
    {
        bombShotSound = GetComponent<AudioSource>();
        bombShotSound.Play();

        // ===================================================
        // Some help from tutorial: https://www.youtube.com/watch?v=Cm3KuIJu9gY&feature=youtu.be
        GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);

        // Add Velocity
        // bomb.GetComponent<Rigidbody>().velocity = bomb.transform.forward * throwBombVelocity;

        Vector3 throwingDirection = (bomb.transform.forward + Vector3.up).normalized; // little boost to launch the bomb
        bomb.GetComponent<Rigidbody>().AddForce(throwingDirection * throwingSpeed);

        // Destroy(bomb, 5); // Destroy Object after 5 seconds.
        // ===================================================

        //GameObject bombObject = Instantiate(bombPrefab);
        //// Set position_Knows where the player is looking at, to throw the bomb
        //bombObject.transform.position = transform.position + model.transform.forward;
        //Vector3 throwingDirection = (model.transform.forward + Vector3.up).normalized; // little boost to launch the bomb
        //bombObject.GetComponent<Rigidbody>().AddForce(throwingDirection * throwingSpeed);

    }
}



