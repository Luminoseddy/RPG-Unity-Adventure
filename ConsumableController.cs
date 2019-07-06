using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SOURCE 20:30 https://www.youtube.com/watch?v=vGEkq9yNzxw&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=9

public class ConsumableController : MonoBehaviour
{
    CharacterStats stats; // Reference to Char stats. 

    void Start()
    {
        stats = GetComponent<Player>().characterStats;
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));

        if (item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
        {
            itemToSpawn.GetComponent<IConsumable>().Consume();
        }
        
    }
}
