using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal 
{
    // Quest goals.
    public string Description 
    { 
        get; set; 
    }
  
    // When goal completed
    public bool Completed
    {
        get; set;
    }

    // how much of the goal has been completed
    public int CurrentAmount
    {
        get; set;
    }

    public int RequiredAmount
    {
        get; set;
    }


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
        Completed = true;
    }
}
