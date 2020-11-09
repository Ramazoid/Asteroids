using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    int counter;
    Renderer rend;
    Color col;
    void Start()
    {
        
        counter = 30;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (--counter <= 0)
        {
            transform.localScale /= 2;
            //Pool.Collect(gameObject);
        }
            
    }
}
