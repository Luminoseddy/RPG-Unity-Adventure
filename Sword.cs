﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats          { get; set; }
    public CharacterStats CharacterStats { get; set; }
    public int CurrentDamage             { get; set; }

    private Animator animator;
    private int currentDamage;

    void Start()
    {
        /* Use this as reference to the object. Use this to trigger animation upon Attack  */
        animator = GetComponent<Animator>();
    }

    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        //Debug.Log(this.name +" attack!");
        /* The string is what the animated attack is called inside th animator. */
        animator.SetTrigger("Base_Attack");
    }
   
    public void PerformSpecialAttack()
    {
        //Debug.Log(this.name + "attack!");
        animator.SetTrigger("Special_Attack");
    }


    /* This happens in the physics engine. */
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            /* Take the enemey, grab its reference / component  */
            col.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
        }
    }
}











/* Old code for basic sword rotations */



//public float swingingSpeed = 2f;      // how fast the weapon moves forward
//public float coolDownSpeed = 2f;      // So when its moving back we have detectors
//public float coolDownDuration = 0.5f; // .5 second player waits before attacking again
//public float attackDuration = 0.5f;   // How long the weapon is doing to be down for 
//public float coolDownTimer = 0.5f;    // Not allow the player to attack again until __ 

//private Quaternion targetRotation;    // For the weapon to swing/rotate
//private bool isAttacking;             // The sword is not going to destroy enemies everytime the collisopn happens. 

//// Fixes the bug of the user colliding against enemey and enemy gets hit without attack
//public bool IsAttacking
//{
//    get
//    {
//        return isAttacking;
//    }
//}

//// Start is called before the first frame update
//void Start()
//{
//    targetRotation = Quaternion.Euler(0, 0, 0);
//}

//// Update is called once per frame
//void Update()
//{
//    if (isAttacking)
//    {
//        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * swingingSpeed);

//    }
//    else
//    {
//        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * coolDownSpeed);
//    }
//    coolDownTimer -= Time.deltaTime;
//}

//public void Attack()
//{
//    if (coolDownTimer > 0f)
//    {
//        // used for methods with return type.
//        // we can use it in methods void, that don't need returns.'
//        // used to stop the flow of instructions.
//        return;
//    }

//    targetRotation = Quaternion.Euler(90, 0, 0);
//    coolDownTimer = coolDownDuration;
//    StartCoroutine(CoolDownWait()); // this means we are already in attacking state
//}


//private IEnumerator CoolDownWait()
//{
//    isAttacking = true;
//    yield return new WaitForSeconds(attackDuration);

//    isAttacking = false; // once timer finishes, we set the state to false

//    targetRotation = Quaternion.Euler(0, 0, 0);
//}
