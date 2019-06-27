using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    /* REFERENCE TO WEAPON CONTROLLER */
    public PlayerWeaponController playerWeaponController;

    public Item sword;
    
    private void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();

        List<BaseStat> swordStats = new List<BaseStat>();

        swordStats.Add(new BaseStat(6, "Power", "Your Level"));
        sword = new Item(swordStats, "Staff");
    }

    private void Update()
    {
        // Testing to equip weapon
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerWeaponController.EquipWeapon(sword);
        }
    }
}
