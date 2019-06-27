using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("You took a sip from the potion.");
    }

    public void Consume(CharacterStats stats)
    {
        Debug.Log("The following stats have been boosted.");
    }
}
