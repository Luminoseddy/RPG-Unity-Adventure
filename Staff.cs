using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff: MonoBehaviour, IWeapon, IProjectileWeapon
{
    public List<BaseStat> Stats      { get; set; }
    public int CurrentDamage         { get; set; }
    public Transform ProjectileSpawn { get; set; }
    private Animator animator;

    Fireball fireball;
    

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        

        /* Use as reference to the object. Use this to trigger animation upon Attack */
        animator = GetComponent<Animator>();
    }

    public void PerformAttack(int Damage)
    {
        //Debug.Log(this.name +"attack!");    
        animator.SetTrigger("Base_Attack");

    }

    public void PerformSpecialAttack()
    {
        //Debug.Log(this.name + "attack!");
        animator.SetTrigger("Special_Attack");
    }

    public void CastProjectile()
    {
        if (fireball)
        {
            Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
            fireballInstance.Direction = ProjectileSpawn.forward;
        }   
    }
}
