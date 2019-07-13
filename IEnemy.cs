using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    Spawner Spawner { get; set; }

    int Experience { get; set; }
    int ID         { get; set; }

    void Die();
    void TakeDamage(int amount);
    void PerformAttack();
}