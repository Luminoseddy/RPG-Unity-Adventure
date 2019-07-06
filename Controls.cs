using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Connected with playerController class
// Source: https://www.youtube.com/watch?v=526OvMqEk_M&list=PLffw8tfWPU2PZvX4o4r-u4O9purAbgcfQ&index=1

[System.Serializable]
public class Controls 
{
    public ControlBinding forwards,
                          backwards,
                          strafeLeft,
                          strafeRight,
                          rotateLeft,
                          rotateRight,
                          walkRun,
                          jump, 
                          autoRun, 
                          dance;
}
