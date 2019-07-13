using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    [SerializeField] private GameObject quests;
    [SerializeField] private string questType;

    public bool   AssignedQuest { get; set; } // Marks the quest, started or finished.
    public bool   Helped        { get; set; }
    private Quest Quest         { get; set; }

    public override void Interact()
    {
        
        if (!AssignedQuest && !Helped)
        {
            base.Interact();
            // Assign quest
            AssignQuest();
        }
        else if(AssignedQuest && !Helped)
        {
            // Check
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for helping me.", "" }, name);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thank you here's your reward", "Testing __" }, name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Sorry, Still currently questing", "Testing __" }, name);
        }
    }
}


