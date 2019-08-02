using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    [SerializeField] private GameObject quests;
    [SerializeField] private string     questType;

    public bool   AssignedQuest { get; set; } // Marks the quest, started or finished.
    public bool   Helped        { get; set; } // Mark as true when you have successfully completed the quest. Basically did you help the questgiver.
    private Quest Quest         { get; set; } /* Used to keep the reference to the component */

    public override void Interact()
    {
        /* If the quest has not been assigned, and has not been helped with */
        if (!AssignedQuest && !Helped) 
        {
            base.Interact();/*  */
            AssignQuest();
        }
        /* If we have been assigned the quest, but has not been completed yet. */
        else if (AssignedQuest && !Helped)
        {      
            CheckQuest();
        }
        else
        {       
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for helping me.", "Good-bye." }, name); /* Response AFTER the quest has been completed. */
        }
      
    }

    void AssignQuest()
    {
        AssignedQuest = true; // Tells us that the quest has been assigned.
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType)); // Makes the Quest appear dynamically.
    }

    void CheckQuest()
    {
        Debug.Log("Check quest status");
        if (Quest.Completed)
        {
            Helped = true;         
            Quest.GiveReward();
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thank you here's your reward", "Good-Bye" }, name);
            AssignedQuest = false;
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "You're not finished.", "Come back when you're finished." }, name);
        }
    }
}


