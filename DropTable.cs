using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable 
{
    public List<LootDrop> loot;

    public Item GetDrop()
    {
        int roll = Random.Range(0, 101); // From 0 - 100
        int weightSum = 0;

        foreach (LootDrop drop in loot)
        {
            weightSum += drop.Weight;
            if(roll < weightSum)
            {
                return ItemDatabase.Instance.GetItem(drop.ItemSlug);
            }
        }
        return null; // Remaining 25% chance of no drop. 
    }
}

// Define what LootDrop is
public class LootDrop
{
    public int    Weight   { get; set; }
    public string ItemSlug { get; set; }
    
    // Constructor
    public LootDrop(string itemSlug, int weight)
    {
        this.ItemSlug = itemSlug;
        this.Weight   = weight;
    }
}
