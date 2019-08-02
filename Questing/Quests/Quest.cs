using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals        { get; set; } 
    public string QuestName        { get; set; }
    public string Description      { get; set; }
    public int    ExperienceReward { get; set; }
    public Item   ItemReward       { get; set; }
    public bool   Completed        { get; set; }

    private int level;
    public int Level
    {
        get { return level; }
        set { level = value; }  
    }

    public void CheckGoals()
    {
        Completed = Goals.All(goal => goal.Completed); /* When it this checks, it marks it as true. */
        if (Completed)
        {
            GiveReward();
        }
    }
    
    public void GiveReward()
    {
        if (ItemReward != null)
        {
            InventoryController.Instance.GiveItem(ItemReward);
        }
    }
}
