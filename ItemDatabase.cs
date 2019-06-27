using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


// SOURCE 11:00 https://www.youtube.com/watch?v=S5fRFS9lNpc&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=10


public class ItemDatabase : MonoBehaviour
{
    private List<Item> Items { get; set; }
    public static ItemDatabase Instance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        BuildDatabase();
    }

    // Update is called once per frame
    // Deserialize the json file into an object/collection/list of items.
    private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
        Debug.Log(Items[0].Stats[0].StatName + " level is " + Items[0].Stats[0].GetCalculatedStatValue());
        Debug.Log(Items[0].ItemName);
    }

    public Item GetItem(string itemSlug)
    {
        // Loop through each "item" type "Item" in "Items", if it finds the match, return the item.
        foreach (Item item in Items)
        {
            if (item.ObjectSlug == itemSlug)
            {
                return item;
            }    
        }
        Debug.LogWarning("Couldn't find items: " + itemSlug);
        return null;
    }
}

        
