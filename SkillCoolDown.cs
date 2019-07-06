using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Source: https://www.youtube.com/watch?v=6dQjLoupAw0

public class SkillCoolDown : MonoBehaviour
{
    public List<Skill> skills;

<<<<<<< HEAD
    public GameObject attackSlot;
    public GameObject player;
    public float distance;
    public bool curserOnAttackSlot;

    public void FixedUpdate()
    {

        // distance = Vector3.Distance(player.transform.position, attackSlot.transform.position);

=======
    public void FixedUpdate()
    {
>>>>>>> 5a8051cc53a55e60c9f35c3335255105807662f7
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(skills[0].currentCoolDown >= skills[0].coolDown)
            {
                skills[0].currentCoolDown = 0;
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


