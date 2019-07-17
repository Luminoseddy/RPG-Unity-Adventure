<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
>>>>>>> 0d010d75a250b66a92269173638113bd8962d523
{
    public GameObject ui;
    public GameObject objectToTeleport;
    public Transform teleportLocation;
<<<<<<< HEAD
=======

>>>>>>> 0d010d75a250b66a92269173638113bd8962d523
    void Start()
    {
        ui.SetActive(false);
    }

<<<<<<< HEAD
    void OnTriggerStay(Collider other)
    {
        ui.SetActive(true);
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.Y))
=======
    private void OnTriggerStay(Collider other)
    {
        ui.SetActive(true);
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.Alpha9))
>>>>>>> 0d010d75a250b66a92269173638113bd8962d523
        {
            objectToTeleport.transform.position = teleportLocation.transform.position;
        }
    }
<<<<<<< HEAD
    void OnTriggerExit()
    {
        ui.SetActive(false);
    }
}
=======

    private void OnTriggerExit()
    {
        ui.SetActive(false);
    }
}
>>>>>>> 0d010d75a250b66a92269173638113bd8962d523
