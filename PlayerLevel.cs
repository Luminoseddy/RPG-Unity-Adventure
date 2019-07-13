using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int Level { get; set; }
    public int CurrentExperience { get; set; }
    public int RequiredExperience { get { return Level * 25; } } // lv 1 needs 25exp, lv 2 50xp, lv 3 75 exp. etc. 


    private void Start()
    {
        // Listening to make sure the enemy dies to give the exp.
        // Subscriber EnemyToExperience
        CombatEvents.OnEnemyDeath += EnemyToExperience;
        Level = 1;  
    }

    public void EnemyToExperience(IEnemy enemy)
    {
        GrantExperience(enemy.Experience);
    }

    // Handler for enemny object to take and turn into exp.
    public void GrantExperience(int amount)
    {
        CurrentExperience += amount;

        while (CurrentExperience >= RequiredExperience)
        {
            CurrentExperience -= RequiredExperience;
            Level++;
        }
        UIEventHandler.OnPlayerLevelChanged();
    }
}
