﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryUIDetails : MonoBehaviour
{
    Item item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractButtonText;

    public Text statText;
    void Start()
    {
        itemNameText           = transform.Find("Item_Name").GetComponent<Text>();
        itemDescriptionText    = transform.Find("Item_Description").GetComponent<Text>();
        itemInteractButton     = transform.Find("Button").GetComponent<Button>();
        itemInteractButtonText = itemInteractButton.transform.Find("Text").GetComponent<Text>();
        gameObject.SetActive(false); // Deactivate the panel.
    }

    public void SetItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true); /* Displays item info when clicked on. */
        statText.text = ""; /* Empty the string when adding data so that they don't concatenate. */

        if (item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats)
            {
                statText.text += stat.StatName + ": " + stat.BaseValue + "\n";
            }
        }
        
        itemInteractButton.onClick.RemoveAllListeners();
        this.item = item;
        selectedItemButton          = selectedButton;
        itemNameText.text           = item.ItemName;
        itemDescriptionText.text    = item.Description;
        itemInteractButtonText.text = item.ActionName;
        itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        // Debug.Log("Testing on item interact: " + item.ItemType.ToString());
  
        if (item.ItemType == Item.ItemTypes.Consumable) // Consumable ItemTypes value.
        {
            InventoryController.Instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipItem(item);
            Destroy(selectedItemButton.gameObject);
        }

        item = null; /* Null out the item once its used */
        gameObject.SetActive(false); /* deactivate panel when using item */
    }
}
