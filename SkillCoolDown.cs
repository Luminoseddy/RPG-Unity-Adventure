using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// Source: https://www.youtube.com/watch?v=6dQjLoupAw0

public class SkillCoolDown : MonoBehaviour
{
    public List<Skill> skills;

    public GameObject attackSlot;
    public GameObject player;
    public float      distance;
    public bool       curserOnAttackSlot;

    public void FixedUpdate()
    {
        // distance = Vector3.Distance(player.transform.position, attackSlot.transform.position);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(skills[0].currentCoolDown >= skills[0].coolDown)
            {
                skills[0].currentCoolDown = 0;
                // Debug.Log("We are clicking the attack button");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (skills[1].currentCoolDown >= skills[1].coolDown)
            {
                skills[1].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (skills[2].currentCoolDown >= skills[2].coolDown)
            {
                skills[2].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (skills[3].currentCoolDown >= skills[3].coolDown)
            {
                skills[3].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (skills[4].currentCoolDown >= skills[4].coolDown)
            {
                skills[4].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (skills[5].currentCoolDown >= skills[5].coolDown)
            {
                skills[5].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (skills[6].currentCoolDown >= skills[6].coolDown)
            {
                skills[6].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (skills[7].currentCoolDown >= skills[7].coolDown)
            {
                skills[7].currentCoolDown = 0;
            }
        }
    }
    void Update()
    {
        foreach (Skill s in skills)
        {
            if (s.currentCoolDown < s.coolDown)
            {
                s.currentCoolDown += Time.fixedDeltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.coolDown;
            }
        }
    }
}
[System.Serializable]
public class Skill
{
    public float coolDown;
    public Image skillIcon;

    [HideInInspector]
    public float currentCoolDown;
}








