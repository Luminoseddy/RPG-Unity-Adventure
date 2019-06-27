﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    /* Few properties Using BaseStats to define all items and weapons */
    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug    { get; set; }
    public string Description   { get; set; }
    public string ActionName    { get; set; }
    public string ItemName      { get; set; }
    public bool   ItemModifier  { get; set; }

    // Constructor
    public Item(List<BaseStat> _Stats, string _ObjectSlug)
    {
        this.Stats      = _Stats;
        this.ObjectSlug = _ObjectSlug;
    }

    // Constructor
    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> _Stats, string _ObjectSlug, string _Description, string _ActionName, string _ItemName, bool _ItemModifier)
    {
        this.Stats        = _Stats;
        this.ObjectSlug   = _ObjectSlug;
        this.Description  = _Description;
        this.ActionName   = _ActionName;
        this.ItemName     = _ItemName;
        this.ItemModifier = _ItemModifier;
    }
}
