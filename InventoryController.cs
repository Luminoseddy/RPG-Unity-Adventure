using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    /* REFERENCE TO WEAPON CONTROLLER */
    public PlayerWeaponController playerWeaponController;

    public ConsumableController consumableController;

    public Item sword;

    public Item PotionLog;
    
    private void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();

        consumableController = GetComponent<ConsumableController>();

        List<BaseStat> swordStats = new List<BaseStat>();

        swordStats.Add(new BaseStat(6, "Power", "Your Level"));
        sword = new Item(swordStats, "Staff");

        PotionLog = new Item(new List<BaseStat>(), "Potion_log",
                                                   "Drink to log testing drink 2 3, ",
                                                   "Drink some more soon...",                                           
                                                   "Log Potion",
                                                    false );
    }

    private void Update()
    {
        // Testing to equip weapon
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerWeaponController.EquipWeapon(sword);
            consumableController.ConsumeItem(PotionLog);
        }
    }
}
