using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    public List<BaseStat> stats = new List<BaseStat>();

    /* Constructor that search for the values of stats to know whats bring assigned to what stat. */
    public CharacterStats(int attack, int strength, int attackSpeed)
    {
        stats = new List<BaseStat>() {
            new BaseStat(BaseStat.BaseStatType.Attack, attack, "Attack"),
            new BaseStat(BaseStat.BaseStatType.Strength, strength, "Strength"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "AttackSpeed")
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat); 
    }

    /* This is called whenever we equip any type of weapon.
     * When equipping weapon this add the stats to the player.
     * Allows you to pass a list of different stats for you in 1 go. att, def, str etc.
     */
    public void AddStatsBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat statBonus in statBonuses)
        {
            /* We have the BaseStat in statBonus. We make a new statBonus out of the
             * BaseStat value and then passes it to the AddStatBonus method.
             */
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    /* Call this when UNEquipting a weapon.
     * Causing the stats to reduce back to its original default values.
     * Same concept as the AddStatBonus, but isntead, we are removing.
     */
    public void RemoveStatsBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        { 
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
