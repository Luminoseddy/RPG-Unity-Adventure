using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Allows user to swap scenes

public class MenuSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    // without public, its default is private.
    public void OnStart()
    {
        SceneManager.LoadScene("Level1");
    }
}
