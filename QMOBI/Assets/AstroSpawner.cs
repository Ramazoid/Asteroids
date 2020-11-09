using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AstroSpawner : MonoBehaviour
{
    public GameObject[] AsteroidPrefabs;
    public int rate = 10;
    private int counter;
    void Start()
    {
        counter = rate;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter--<=0)
        {
            counter = rate;
            SpawnOne();

        }
        
    }
    void SpawnOne()
    {
        int n = Random.Range(0, AsteroidPrefabs.Length);
        Vector2 pos2 = Random.insideUnitCircle * 100;
        Vector3 pos3 = new Vector3(pos2.x, 0, pos2.y);

        GameObject a = Pool.GetAsteroid();
        Rigidbody r;
        if (a == null)
        {
            a = Instantiate(AsteroidPrefabs[n], pos3, Quaternion.identity);
            a.AddComponent<SphereCollider>();
            PoolCollector pc = a.AddComponent<PoolCollector>();
            pc.kind = "Asteroid";
            r = a.AddComponent<Rigidbody>();
            r.useGravity = false;

        }
        else
        {
             r = a.GetComponent<Rigidbody>();
        }

        a.transform.localScale = Vector3.one * Random.Range(50, 100);
       
        Vector2 target = Random.insideUnitCircle+ Random.insideUnitCircle*2;
        Vector3 targ = new Vector3(target.x, 0, target.y);
        if (r != null)
        {
            r.velocity = targ * 2;
            r.angularVelocity = Random.insideUnitSphere * 2;
        }
        
    }
}
