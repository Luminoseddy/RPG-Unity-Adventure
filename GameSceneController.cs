using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameSceneController : MonoBehaviour
{

    [Header("Game")]
    public Player player;

    [Header("UI")]
    public GameObject[] hearts;
    public Text healthText;
    public Text bombText;
    public Text arrowText;
    public Text bulletText;
    public Text experienceText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        // determine the health is only updated if the player exist
        if (player != null){

            bombText.text = "Bombs: " + player.bombAmount;
            arrowText.text = "Arrows: " + player.arrowAmount;
            bulletText.text = "Ammu: " + player.bulletAmount;
            // experienceText.text = "Exp: " + player.experienceAmount;

            // Passes through the index of hearts
            for (int i = 0; i < hearts.Length; i++)
            {
                //hearts[i].SetActive(i < player.currentHealth);
            }

        } else {
            healthText.text = "Health: 0";
            for (int i = 0; i < hearts.Length; i++){
                hearts[i].SetActive(false);
            }
        }
    }
}
