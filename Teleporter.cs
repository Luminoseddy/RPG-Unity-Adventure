using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public GameObject ui;
    public GameObject objectToTeleport;
    public Transform teleportLocation;
    void Start()
    {
        ui.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        ui.SetActive(true);
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.Y))
        {
            objectToTeleport.transform.position = teleportLocation.transform.position;
        }
    }
    void OnTriggerExit()
    {
        ui.SetActive(false);
    }
}