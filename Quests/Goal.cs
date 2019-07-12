using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Quest  Quest          { get; set; }
    public bool   Completed      { get; set; } // When goal completed
    public int    CurrentAmount  { get; set; } // how much of the goal has been completed
    public int    RequiredAmount { get; set; }
    public string Description    { get; set; } // Quest goals.
    
    public virtual void Init()
    {
        // default init
    }

    public void Evaluate()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Quest.CheckGoals();
        Completed = true;
    }
}
