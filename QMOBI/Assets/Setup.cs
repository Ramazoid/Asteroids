using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public float elevation;
    public static Setup inst;
    
    // Start is called before the first frame update
    void Start()
    {
        inst = this;
        Camera.main.transform.position = new Vector3(0, elevation, elevation);
        Camera.main.transform.LookAt(Vector3.zero);
        Game.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
