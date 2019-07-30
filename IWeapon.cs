using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Interface contains only the declaration of the methods, properties, and events, but not the implementation.
 * It is left to the class that implements the interface by providing implementation for all the members of the interface. 
 * Interface makes it easy to maintain a program.
 */
public interface IWeapon 
{
    /* Using BaseStats to define a way to define the stats for weapons */
    List <BaseStat> Stats { get; set; }

    int CurrentDamage { get; set; }

    /* Each weapon will have this method. */
    void PerformAttack(int damage);

    /* Some weapons will have this method. */
    void PerformSpecialAttack();
}