using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBonus 
{
    /* Whenever new statBonus is created, we add it to this property,
     * So if we equip a sword, that added power, then we add the BonusValue using
     * this constructor to add 5 power to that weapon. */
    public int BonusValue { get; set; }


    public StatBonus(int bonusValue)
    {
        this.BonusValue = bonusValue;
        // Debug.Log("This is the new stat bonus initiating.");
    }
}
