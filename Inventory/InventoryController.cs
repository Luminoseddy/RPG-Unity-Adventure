using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryController : MonoBehaviour
{

    /* REFERENCE TO WEAPON CONTROLLER */
    public List<Item> playerItems = new List<Item>();

    public static InventoryController Instance { get; set; }
    public PlayerWeaponController     playerWeaponController;
    public ConsumableController       consumableController;
    public InventoryUIDetails         inventoryUIDetailsPanel;

    public Item sword;
    public Item PotionLog;
    
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
        consumableController   = GetComponent<ConsumableController>();

        GiveItem("sword");
        GiveItem("potion_log");

        //List<BaseStat> swordStats = new List<BaseStat>();
        //swordStats.Add(new BaseStat(6, "Power", "Your Level"));
        //sword = new Item(swordStats, "Staff");
        //PotionLog = new Item(new List<BaseStat>(), "Potion_log", "Drink to log testing drink 2 3", "Drink some more soon...", "Log Potion", false);                                                
    }

    // Let the slug go through the database, and grab the instance.
    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        playerItems.Add(item);
        Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
        UIEventHandlerController.ItemAddedToInventory(item);
    }



    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryUIDetailsPanel.SetItem(item, selectedButton);
    }




    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }





    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }

    //private void Update()
    //{
    //    // Testing to equip weapon
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        playerWeaponController.EquipWeapon(sword);
    //        consumableController.ConsumeItem(PotionLog);
    //    }
    //}
}

