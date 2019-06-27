using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCircles : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, -1f, 0f);
    }
}
