using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface XWeapon 
{
    List <BaseStat> Stats { get; set; }

    void PerformAttack();
    void PerformSpecialAttack();
}