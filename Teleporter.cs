using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject ui;
    public GameObject objectToTeleport;
    public Transform teleportLocation;

    void Start()
    {
        ui.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        ui.SetActive(true);
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.Alpha9))
        {
            objectToTeleport.transform.position = teleportLocation.transform.position;
        }
    }

    private void OnTriggerExit()
    {
        ui.SetActive(false);
    }
}
