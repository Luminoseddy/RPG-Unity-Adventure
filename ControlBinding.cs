using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Source: https://www.youtube.com/watch?v=PcHZAmomdVU&list=PLffw8tfWPU2PZvX4o4r-u4O9purAbgcfQ&index=5




[System.Serializable]
public class ControlBinding 
{
    public KeyCode[] primary = new KeyCode[1], secondary;

    public bool GetControlBinding()
    {

        bool primaryPressed = false;
        bool secondaryPressed = false;

        // Primary
        if (primary.Length == 1)
        {
            if (Input.GetKey(primary[0]))
                primaryPressed = true;
        }
        else if (primary.Length == 2)
        {
            if ((Input.GetKey(primary[0])) && (Input.GetKey(primary[1])))
            {
                primaryPressed = true;
            }

        }

        // Secoondary 
        if (secondary.Length == 1)
        {
            if (Input.GetKey(secondary[0]))
                secondaryPressed = true;
        }
        else if (secondary.Length == 2)
        {
            if ( Input.GetKey(secondary[0]) && Input.GetKey(secondary[1]) )
            {
                secondaryPressed = true;
            }

        }

        // Check Keybindings
        if (primaryPressed || secondaryPressed)
        {
            return true;
        }
        return false;
    }

    bool unpressed;

    public bool GetControlBindingDown()
    {

        bool primaryPressed = false;
        bool secondaryPressed = false;

        // Primary
        if (primary.Length == 1)
        {
            if (Input.GetKey(primary[0]))
                primaryPressed = true;
        }
        else if (primary.Length == 2)
        {
            if ((Input.GetKey(primary[0])) && (Input.GetKey(primary[1])))
            {
                primaryPressed = true;
            }

        }

        // Secoondary 
        if (secondary.Length == 1)
        {
            if (Input.GetKey(secondary[0]))
                secondaryPressed = true;
        }
        else if (secondary.Length == 2)
        {
            if ((Input.GetKey(secondary[0])) && (Input.GetKey(secondary[1])))
            {
                secondaryPressed = true;
            }

        }
        // if we have not pressed anything, and then we press something, we set unpress to true, and then return true
        if (!unpressed)
        {
            if (primaryPressed || secondaryPressed)
            {
                unpressed = true;
                return true;
            }
        }
        // If unpress is true, and we're not pressing anything, then set unpress to false.
        else if (!primaryPressed && !secondaryPressed) 
        {
            unpressed = false;
        }
        return false;
    }
}
