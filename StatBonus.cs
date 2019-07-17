using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://www.youtube.com/watch?v=wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5


public class StatBonus 
{

    public int BonusValue { get; set; }

    // Constructor
    public StatBonus(int bonusValue)
    {
        this.BonusValue = bonusValue;
        Debug.Log("This is the new stat bonus initiating.");
    }
}
