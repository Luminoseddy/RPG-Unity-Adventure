﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Ultimate Slayer";
        Description = "Kill the skeletons on the other island across the bridge.";
        ItemReward = ItemDatabase.Instance.GetItem("Heal_Potion");
        ExperienceReward = 100;

        Goals = new List<Goal>
        {
            /* Quest: EneryId 0, description, completed?, currentAmount, requiredAmount. */
            new KillGoal(this, 0, "Kill 30 Skelly's", false, 0, 4),

            /* 'this' being the object of ultimate slayer, and the object being a quest. */
            //new KillGoal(this, 1, "Kill 1 Demons in the Karamja Island.", false, 0, 2),

            // Quest 2
            // new CollectionGoal(this, "Heal_Potion", "Find the potion that heals.", false, 0, 1)
        };

    /* Loop through each item(Goal) in the collection */ 
    Goals.ForEach(goal => goal.Init());
    }
}

