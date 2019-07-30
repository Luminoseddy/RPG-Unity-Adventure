using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBonus 
{
    public int BonusValue { get; set; }

    /* A constructor is a special method of the class which gets automatically invoked
     * whenever an instance of the class is created. Like methods, a constructor also contains
     * the collection of instructions that are executed at the time of Object creation.
     * It is used to assign initial values to the data members of the same class.
     */
    public StatBonus(int bonusValue)
    {
        this.BonusValue = bonusValue;
        // Debug.Log("This is the new stat bonus initiating.");
    }
}
