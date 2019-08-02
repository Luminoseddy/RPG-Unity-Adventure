using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsumable 
{
    void Consume();

    /* Consumable that effects character stats needs a reference to the char stats. */
    void Consume(CharacterStats stats); 
}
