using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Movement;
    public float speed = 1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Movement;

    }
    public void SetDirection(Vector3 forward)
    {
        Movement = forward * speed;
    }
    private void OnCollisionEnter(Collision col)
    {
        print(col.collider.name);


        Exploder.Explode(col.collider.gameObject);
        Sounds.PlayRandom("Explosion");
        Game.IncreaseScore();
    }
}
