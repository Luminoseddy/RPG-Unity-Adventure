using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




// Source from: https://www.youtube.com/watch?v=tCe_UfyirT4

public class LoadToLevel : MonoBehaviour
{

    public GameObject guiObject; // Text that appears when near the trigger object
    public string loadToLevel; // The name of the level

    void Start()
    {
        guiObject.SetActive(false); // disabling the object when not in the trigger
    }

    // Update is called once per frame
    [System.Obsolete]
    void OnTriggerStay(Collider other)
    {
        // Checks if the tag player has collided
        if (other.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use")) // We want the text to appear to know how to enter
            {
                Application.LoadLevel(loadToLevel);
            }
        }
    }
    void OnTriggerExit()
    {
        //if (player.gameObject.tag == "Player")
        //{
            guiObject.SetActive(false); // When we exit its false
        //}
    }
}