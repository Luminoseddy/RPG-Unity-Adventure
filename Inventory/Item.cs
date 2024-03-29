﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item 
{
    /* Few properties Using BaseStats to define all items and weapons
     * This is used inside the JSON File.  */
    public enum ItemTypes { Consumable, Weapon, Quest }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType   { get; set; }
    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug    { get; set; } 
    public string Description   { get; set; }
    public string ActionName    { get; set; }
    public string ItemName      { get; set; }
    public bool   ItemModifier  { get; set; }/* Checks if it will modify stats of the player */

    /* Constructor: invoked whenever an instance of the class is created. -> Item item = new Item(); <-  */
    public Item(List<BaseStat> _Stats, string _ObjectSlug)
    {
        this.Stats      = _Stats;
        this.ObjectSlug = _ObjectSlug;
    }

    /* Item Constructor */
    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> _Stats, string _ObjectSlug, string _Description, ItemTypes _ItemType, string _ActionName, string _ItemName, bool _ItemModifier)
    {
        this.Stats        = _Stats;
        this.ObjectSlug   = _ObjectSlug;
        this.Description  = _Description;
        this.ItemType     = _ItemType;
        this.ActionName   = _ActionName;
        this.ItemName     = _ItemName;
        this.ItemModifier = _ItemModifier;
    }
}

// For the new object we want to instatiate.
// Use same model, same prefab for 1000000 sword, while each containing different stats. 
// We need someting to define what that item is other than its name:
// Using objectslug allows us to access the model. prefab, object type. 
