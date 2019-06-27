using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    /* Few properties Using BaseStats to define all items and weapons */

    public List<BaseStat> Stats { get; set; }

    public string ObjectSlug { get; set; }

    // Constructor
    public Item(List<BaseStat> _Stats, string _ObjectSlug)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
    }
}
