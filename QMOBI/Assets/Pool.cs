using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    
    public List<GameObject> Astropoolist;
    public List<GameObject> bulletpoolist;
    public Queue<GameObject> Asterpool;
    public Queue<GameObject> Bulletpool;
    static public Pool inst;
    

    void Start()
    {
        inst = this;
        Asterpool = new Queue<GameObject>();
        Bulletpool = new Queue<GameObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Astropoolist = Asterpool.ToList<GameObject>();
        bulletpoolist = Bulletpool.ToList<GameObject>();
    }

    internal static void Collect(GameObject go, string kind)
    {
        switch (kind)
        {
            case "Asteroid":
                {
                    if (!inst.Asterpool.Contains(go))
                    {
                        inst.Asterpool.Enqueue(go);
                        go.SetActive(false);
                    }
                }
                break;
            case "Bullet":
                {
                    if (!inst.Bulletpool.Contains(go))
                    {
                        inst.Bulletpool.Enqueue(go);
                        go.SetActive(false);
                    }
                }
                break;
        }
    }
    public static GameObject GetAsteroid()
    {
        if (inst.Asterpool.Count > 0)
        {
            return inst.Asterpool.Dequeue();

        }
        return null;
    }
    public static GameObject GetBullet()
    {
        if (inst.Bulletpool.Count > 0)
        {
            return inst.Bulletpool.Dequeue();

        }
        return null;
    }
}
