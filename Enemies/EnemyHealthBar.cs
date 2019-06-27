using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Source: 
// https://www.youtube.com/watch?v=CA2snUe7ARM


public class EnemyHealthBar : MonoBehaviour
{

    [SerializeField]
    private Image foregroundImage;

    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    private void Awake() { GetComponentInParent<Enemy>().OnHealthPctChanged += HandleHealthChanged; }
 
    private void HandleHealthChanged(float pct) { StartCoroutine(ChangeToPct(pct)); }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }
        foregroundImage.fillAmount = pct;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        //transform.LookAt(Camera.main.transform);
        //transform.Rotate(0, 180, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
