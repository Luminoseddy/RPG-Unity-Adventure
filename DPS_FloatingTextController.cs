using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS_FloatingTextController : MonoBehaviour
{
    private static DPS_FloatingText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas_DPS_Display");
        if (!popupText)
            popupText = Resources.Load<DPS_FloatingText>("UI/PopupText_Parent");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        DPS_FloatingText instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

        instance.transform.SetParent(canvas.transform, false); /* Always set parent if you haev the UI often changing. */
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
}
