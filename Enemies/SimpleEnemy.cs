using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We are extending Enemy which also extends MonoBehaviour
public class SimpleEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Override from Enemy
    public override void Hit(){
        base.Hit();
    }
}
