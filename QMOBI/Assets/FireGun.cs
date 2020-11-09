using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{

    public float BulletSize = 0.5f;
    void Start()
    {
        

    }

    private Bullet CreateBullet()
    {
        GameObject bullet;
        bullet = Pool.GetBullet();
        if (bullet == null)
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.AddComponent<SphereCollider>();
            PoolCollector pc = bullet.AddComponent<PoolCollector>();
            pc.kind = "Bullet";
            return bullet.AddComponent<Bullet>();

        }
        bullet.transform.localScale = Vector3.one * BulletSize;
        bullet.name = "Bullet";

        return bullet.GetComponent<Bullet>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
        Bullet bullet=CreateBullet();
        bullet.transform.position = transform.position - transform.forward*BulletSize*10;
        bullet.SetDirection(-transform.forward);
        Sounds.PlayRandom("Bullet");
    }
}
