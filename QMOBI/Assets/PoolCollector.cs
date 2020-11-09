using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCollector : MonoBehaviour
{
    // Start is called before the first frame update
    public string kind;
    Renderer rend;
    bool wasVisible;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.isVisible)
        {
            wasVisible = true;
        }
            
        else if (!rend.isVisible&& wasVisible)
        {
            
            Pool.Collect(gameObject,kind);
        }
    }
}
