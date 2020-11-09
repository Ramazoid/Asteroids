using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public GameObject fxPrefab;
    static Exploder inst;
    public GameObject explosion;
    public int expcounter;
    void Start()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Explode(GameObject go)
    {
        inst.explosion = Instantiate<GameObject>(inst.fxPrefab, go.transform.position,Quaternion.identity);
        inst.explosion.AddComponent<TimeDestroyer>();
        Destroy(go);
        
    }
}
