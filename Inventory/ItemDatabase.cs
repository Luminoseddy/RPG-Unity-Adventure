using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    private List<Item>         Items    { get; set; }
    public static ItemDatabase Instance { get; set; }

    void Awake()
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


    /* Deserialize the json file into an object/collection/list of items. */
    private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
    }

    public Item GetItem(string itemSlug)
    {
        /* Loop through each "item" type "Item" in "Items", if it finds the match, return the item. */
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

        
