using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public GameObject model;
    public GameObject bulletPrefab; // REfference.


    private Quaternion targetRotaton; // how the enemy rotates.
    private int targetAngle; // To change angles we have
    public int startingAngle = 0;

    public float  timeToRotate = 2f;
    public float  rotationSpeed = 6f;
    public float  timeToShoot = 1f; // 1 bullet every second
    private float rotationTimer;
    private float shootingTimer;

    public bool rotateClockwise = true;

    void Start(){
        rotationTimer = timeToRotate;
        shootingTimer = timeToShoot;

        targetAngle = startingAngle;
        transform.localRotation = Quaternion.Euler(0, targetAngle, 0);
    }

    void Update(){
        // Update enemy angle
        rotationTimer -= Time.deltaTime;
        // Resets the timer
        if(rotationTimer <= 0f){
            rotationTimer = timeToRotate;

            // if clockWise true, turn 90, else turn -90
            targetAngle += rotateClockwise ? 90: - 90 ;

        }
        //Perform enemy rotation
        //Linear interpelation, goes from localRotation of player to (0, targetAngle, 0)
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, targetAngle, 0), Time.deltaTime * rotationSpeed);
        shootingTimer -= Time.deltaTime;

        if (shootingTimer <= 0f){
            shootingTimer = timeToShoot;

            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = transform.position + model.transform.forward;
            bulletObject.transform.forward = model.transform.forward;

           
        }
    }
   
}
 
