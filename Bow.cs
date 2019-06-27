using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    private AudioSource arrowShotSound;
    public void Attack()
    {

        arrowShotSound = GetComponent<AudioSource>();
        arrowShotSound.Play();
        //GameObject arrowObject = Instantiate(arrowPrefab);
        //arrowObject.transform.position = transform.position + transform.forward;

        //// Logic for arrow to mvoe forward
        //arrowObject.transform.forward = transform.forward; // Makes arrow point wherever you're facing

        // GameObject bulletObject = Instantiate(bulletPrefab);
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);
        // bulletObject.transform.position = (transform.position + transform.forward);

        // Logic for bullet to move forward
        //bulletObject.transform.forward = transform.forward; // Makes bullet point wherever you're facing

    }
}
