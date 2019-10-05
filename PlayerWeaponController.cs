using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    /* Determine what weapon is equipped to the hand. */
    [HideInInspector] public GameObject EquippedWeapon { get; set; }

    /* Reference to the player hand. */
    public GameObject playerHand;

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
        /* This is where we destroy the item in the players hand to swap/remove weapons. */
        if(EquippedWeapon != null) 
        {
            UnequipWeapon();
        }
        /* Going inside our 'Resources' folder and searching our weapon  */
        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);

        /* And we now know that this equipped weapon will contain stas from IWeapon*/
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        /* Not all weapons are projectile weapons, hence we need to check the type of weapon is being equipped. */
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        /* Setting Parent to parent it to playersHand (changes Parents) and becomes parented to players hand. */
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        /* After equipping, we add the stat bonuses. */
        characterStats.AddStatsBonus(itemToEquip.Stats);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon()
    {
        InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);       // Gives us back the item.
        characterStats.RemoveStatsBonus(EquippedWeapon.GetComponent<IWeapon>().Stats); // Remove the stats of the equipt item.
        Destroy(playerHand.transform.GetChild(0).gameObject);                          // Destory the item that was currently equipped
        UIEventHandler.StatsChanged();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			PerformWeaponAttack();
		}
        
        if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			PerformWeaponSpecialAttack();
		}
    }

    public void PerformWeaponAttack()
    {
        /* Equip weapon when attack - PerformAttack() from Sword.cs class */
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
        // Debug.Log("Damage dealt: " + damageToDeal);
     
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
