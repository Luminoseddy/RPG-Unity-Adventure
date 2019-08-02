using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DPS_FloatingText : MonoBehaviour
{
    public Animator animator;
    private Text damageText;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        // Debug.Log(clipInfo.Length); 
        Destroy(gameObject, clipInfo[0].clip.length); /* Waits before destroying the gameObject. Once the length runs out, Poof.. Destory */
        damageText = animator.GetComponent<Text>(); /* Get the Text component object that contains the animator. */
    }

    /* Update the DPS text of the UI. */
    public void SetText(string text)
    {
        damageText.text = text;
    }   
}
