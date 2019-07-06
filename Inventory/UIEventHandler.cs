using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    // Delegates
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemEquipped;

    public delegate void PlayerHealthEventHandler(int health);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;
    public delegate void StatsEventHandler(); // Grab the new copy of the refference and punch it into the UI
    public static event StatsEventHandler OnStatsChanged;
    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevel;


    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemEquipped(Item item)
    {
        OnItemEquipped(item);
    }

    public static void HealthChanged(int health)
    {
        OnPlayerHealthChanged(health);
    }


    public static void StatsChanged(int health)
    {
        OnStatsChanged();
    }

    public static void PlayerLeveled()
    {
        OnPlayerLevel();
    }

}
