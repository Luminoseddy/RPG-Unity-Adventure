using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Die then respawn.
// Source: 
// https://www.youtube.com/watch?v=nBgCeJBMT0k

public class RespawnPoint : MonoBehaviour
{

    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter()
    {
        Player.transform.position = respawnPoint.transform.position;
    }
}
