using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

public class BaseStat : MonoBehaviour
{
    /* By default, the first member of an enum has the value 0 and the value of each successive enum member is increased by 1. */
    public enum BaseStatType { Attack, Strength, AttackSpeed }
    public List<StatBonus> BaseAdditives { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType;

    /* Getters and setters are known as properties.
     * Auto-implemented property when it contains an
     * accessors(get, set) without having any logic implementation. */
    public int    BaseValue       { get; set; } /* Default stats with no armor, no nothing. */
    public string StatName        { get; set; } /* Display in character sheet in game. */
    public string StatDescription { get; set; }
    public int    FinalValue      { get; set; }

    /* Constructor initialize the objects of a class. */
    public BaseStat(int baseValue, string statName, string statDescription)
    {
        /* Everytime new stat is created, it has an empty list of stat bonuses that it starts from and then gets created. */
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }

    /* Take a string representation of enum, represented by the index value.
     * IF we look inside the Json file, the paramters below match the text within. */
    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        /* Everytime new stat is created, it has an empty list of stat bonuses that it starts from and then gets created. */
        this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    /* Adds stats when any weapon is equipped */
    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        /* Goes through the BassAdditive list, find the value that matches the StatbonusValue that we passed in, and then apply the remove method. */
        this.BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        /* Lamba operation, x is an additive with bonus propety */
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }
}
