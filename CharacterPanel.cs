using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private Text health, level;
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Player player; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set up the listener
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
    }

    void UpdateHealth(int health)
    {
        this.health.text = health.ToString();
        this.healthFill.fillAmount = (float)health / (float)health;
    }
}
