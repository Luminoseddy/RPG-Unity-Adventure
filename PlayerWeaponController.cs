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
    Item currentlyEquippedItem;
    CharacterStats characterStats;
    IWeapon equippedWeapon;

    void Start()
    {
        spawnProjectile = transform.Find("ProjectileSpawn");
        characterStats = GetComponent<Player>().characterStats;
    }

    public void EquipWeapon(Item itemToEquip)
    {
        // This is where we destroy the item in the players hand. to swap/remove weapons.
        if(EquippedWeapon != null) 
        {
            InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
            characterStats.RemoveStatsBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        // Going inside our 'Resources' folder and searching our only weapon called ObjectSlug
        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        // Not all weapons are projectile weapons, hence we need to check the type of weapon is being equipped.
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        // Setting Parent to parent it to playersHand (changes Parents) and becomes parented to players hand.
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        characterStats.AddStatsBonus(itemToEquip.Stats);
        // Debug.Log(equippedWeapon.Stats[0].GetCalculatedStatValue());
        UIEventHandler.ItemEquipped(itemToEquip); // Current item trying to equip gets passed to the UI: DEBUGG
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			PerformWeaponAttack();
		}
        if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			PerformWeaponSpecialAttack();
		}
    }

    public void PerformWeaponAttack()
    {
        // Equip weapon when attack - PerformAttack() from Sword.cs class
        equippedWeapon.PerformAttack(CalculateDamage());
        
    }

    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }

    private int CalculateDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Strength).GetCalculatedStatValue() * 2) + Random.Range(2, 8);
        damageToDeal += CalculateCritical(damageToDeal);

        Debug.Log("Damage dealt: " + damageToDeal);
        return damageToDeal;
    }

    private int CalculateCritical(int damage)
    {
        if (Random.value <= .10f) // .xx% critical hit chance.
        {
            int criticalDamage = (int)(damage * Random.Range(.25f, .5f));
            return criticalDamage;
        }
        return 0;
    }
}
