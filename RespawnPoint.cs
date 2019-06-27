using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Die then respawn.
// Source: 
// https://www.youtube.com/watch?v=nBgCeJBMT0k

public class RespawnPoint : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
     
    void OnTriggerEnter(Collider other){
        player.transform.position = respawnPoint.transform.position;
    }
}
