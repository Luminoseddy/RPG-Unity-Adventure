using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://www.youtube.com/watch?v=wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5


public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();

    void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Power level")); // Beggining Stats
        stats.Add(new BaseStat(10,"Vitality", "Vitality level")); // Beggining Stats

        //stats[0].AddStatBonus(new StatBonus(5)); // Adding a bonus on top of - Power: default stat 4
        //Debug.Log(stats[0].GetCalculatedStatValue());
    }
}
