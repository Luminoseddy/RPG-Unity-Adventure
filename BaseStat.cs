using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Source: https://www.youtube.com/watch?v=wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5


public class BaseStat : MonoBehaviour
{
    public List<StatBonus> BaseAdditives { get; set; }

    public int BaseValue          { get; set; } // Default stats with no armor, no nothing.
    public string StatName        { get; set;  } // Display in character sheet in game
    public string StatDescription { get; set; }
    public int FinalValue         { get; set; }


    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BaseAdditives = new List<StatBonus>();// Everytime new stat is created, it has an empty list of stat bonuses that it starts from and then gets created.
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }

    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(int baseValue, string statName)
    {
        this.BaseAdditives = new List<StatBonus>();// Everytime new stat is created, it has an empty list of stat bonuses that it starts from and then gets created.
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        // Lamba operation, x is an additive with bonus propety
        this.BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        // Lamba operation, x is an additive with bonus propety
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }
}
