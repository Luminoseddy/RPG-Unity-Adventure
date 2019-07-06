using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://www.youtube.com/watch?v=wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5

public class CharacterStats
{
    public List<BaseStat> stats = new List<BaseStat>();
    // Constructor that search for the values of stats to know whats bering assigned to what stat
    public CharacterStats(int attack, int strength, int attackSpeed)
    {
        stats = new List<BaseStat>() {
            new BaseStat(BaseStat.BaseStatType.Attack, attack, "Attack"),
            new BaseStat(BaseStat.BaseStatType.Strength, strength, "Strength"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "AttackSpeed")

        };
    }

    //void Start()
    //{
    //    // Adding a bonus on top of - Power: default stat 4
    //    stats.Add(new BaseStat(1, "Power", "Power level"));     // Beggining Stats
    //    stats.Add(new BaseStat(10,"Vitality", "Vitality level")); 
    //}

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat); 
    }

    // When equipping weapon this add the stats to the player.
    // Allows you to pass a list of different stats for you in 1 go. att, def, str etc.
    public void AddStatsBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat statBonus in statBonuses)
        {
            // stats.Find( x => x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    // Call this when UNEquipting that weapon.
    // Causing the stats to reduce back to its original default values.
    public void RemoveStatsBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        { 
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
