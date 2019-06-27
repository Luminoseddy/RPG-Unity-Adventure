using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private AudioSource gunShotSound;

    public void Attack()
    {
        gunShotSound = GetComponent<AudioSource>();
        gunShotSound.Play();
        // GameObject bulletObject = Instantiate(bulletPrefab);
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        // bulletObject.transform.position = (transform.position + transform.forward);

        // Logic for bullet to move forward
        //bulletObject.transform.forward = transform.forward; // Makes bullet point wherever you're facing

    }
}

