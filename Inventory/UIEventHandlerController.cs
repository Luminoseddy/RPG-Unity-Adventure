using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandlerController : MonoBehaviour
{
    // Delegates
    public delegate void ItemEventHandler(Item item);

    public static event ItemEventHandler OnItemAddedToInventory;

    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }
}
