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
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
    }

    void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = currentHealth / maxHealth; // Pops it into fillAmount
    }
}
