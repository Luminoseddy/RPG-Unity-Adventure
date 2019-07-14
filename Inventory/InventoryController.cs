using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryController : MonoBehaviour
{
    /* REFERENCE TO WEAPON CONTROLLER */
    public static InventoryController Instance { get; set; }

    public PlayerWeaponController     playerWeaponController;
    public ConsumableController       consumableController;
    public InventoryUIDetails         inventoryUIDetailsPanel;
    public List<Item>                 playerItems = new List<Item>();

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
        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();

        GiveItem("Heal_Potion");
        GiveItem("Staff_Of_Pain");
        GiveItem("Sword"); // Strings must match JSON itemSlug strings.
        
    }
    // Let the slug go through the database, and grab the instance.
    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug); // Talk to UI and add to list
        // playerItems.Add(item);
        Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug); // Tells you # of items and then what the item is from itemSlug
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void GiveItem(Item item)
    {  
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryUIDetailsPanel.SetItem(item, selectedButton);
    }

    public void EquipItem(Item itemToEquip) // Access instance of InventoryController
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }

    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }

    //void Update()
    //{
    //    // Testing to equip weapon
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        playerWeaponController.EquipWeapon(sword);
    //        consumableController.ConsumeItem(potionLog);
    //    }
    //}
}

