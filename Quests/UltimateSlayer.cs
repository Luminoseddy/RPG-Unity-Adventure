using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        QuestName   = "Ultimate Slayer";
        Description = "Kill the skeletons behind the Blue's Inn.";
        ItemReward  = ItemDatabase.Instance.GetItem("Heal_Potion");
        ExperienceReward = 100;


        // Quest 0
        Goals.Add(new KillGoal(0, "Kill 5 Skelly behind the Blue's Inn.", false, 0, 5)); 

        // Quest 1
        Goals.Add(new KillGoal(1, "Kill 3 Demons in the Karamja Island.", false, 0, 3));

        Goals.ForEach(goal => goal.Init());
    }
}
