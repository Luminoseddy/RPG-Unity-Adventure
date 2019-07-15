using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    [SerializeField] private GameObject quests;
    [SerializeField] private string     questType;

    public bool   AssignedQuest { get; set; } // Marks the quest, started or finished.
    public bool   Helped        { get; set; } // Mark as true when you have successfully completed the quest. Basically did you help the questgiver.
    private Quest Quest         { get; set; }

    public override void Interact()
    {
        if (!AssignedQuest && !Helped) 
        {
            base.Interact();
            AssignQuest();
        }
        else if(AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for helping me.", "Good-bye." }, name);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true; // Tells us that the quest has been assigned.
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType)); // Makes the Quest appear dynamically.
       
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thank you here's your reward", "Good-Bye" }, name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "You're not finished.", "Come back when you're finished." }, name);
        }
    }
}


