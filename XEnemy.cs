using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface XEnemy
{
    void TakeDamage(int amount);
    void PerformAttack();
}