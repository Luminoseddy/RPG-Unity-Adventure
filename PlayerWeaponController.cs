using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source @ 43:50 -- https://www.youtube.com/watch?v=7T4dFqT62Js&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=6

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;

    [HideInInspector]
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    CharacterStats characterStats;
    XWeapon equippedWeapon;

    private void Start()
    {
        spawnProjectile = transform.FindChild("ProjectileSpawn");

        characterStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        // This is where we destroy the item in the players hand. to swap/remove weapons.
        if(EquippedWeapon != null) 
        {
            characterStats.RemoveStatsBonus(EquippedWeapon.GetComponent<XWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }


        // Casting gameobject 
        // Going inside our 'Resources' folder and searching our only weapon called ObjectSlug
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),playerHand.transform.position, playerHand.transform.rotation);

        equippedWeapon = EquippedWeapon.GetComponent<XWeapon>();

        // Not all weapons are projectile weapons, hence we need to check the type of weapon is being equipped.
        if (EquippedWeapon.GetComponent<XProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<XProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        
        equippedWeapon.Stats = itemToEquip.Stats;

        // Setting Parent to parent it to playersHand (changes Parents) and becomes parented to players hand.
        EquippedWeapon.transform.SetParent(playerHand.transform);

        characterStats.AddStatsBonus(itemToEquip.Stats);

        Debug.Log(equippedWeapon.Stats[0].GetCalculatedStatValue());
    }

    private void Update()
    {
        // Testing to equip weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PerformWeaponAttack();
        }

        // Testing to equip weapon
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PerformWeaponSpecialAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        // Equip weapon when attack - PerformAttack() from Sword.cs class
        equippedWeapon.PerformAttack();
    }

    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }
}
