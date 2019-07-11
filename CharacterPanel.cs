using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private Text health, level;
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Player player;


    //Stats
    private List<Text> playerStatsTexts = new List<Text>();
    [SerializeField] private Text playerStatPrefab;
    [SerializeField] private Transform playerStatPanel;


    // Start is called before the first frame update
    void Start()
    {
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnItemEquipped += EquipWeapon;
        InitializeStats();
    }

    void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth; // Pops it into fillAmount
    }

    void InitializeStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatsTexts.Add(Instantiate(playerStatPrefab));
            playerStatsTexts[i].transform.SetParent(playerStatPanel);
        }
        UpdateStats();
    }


    void UpdateStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatsTexts[i].text = player.characterStats.stats[i].StatName + ": " + player.characterStats.stats[i].GetCalculatedStatValue().ToString();
       
        }
    }

    void EquipWeapon(Item item)
    {
        Debug.Log(item.ItemName);
    }
}
