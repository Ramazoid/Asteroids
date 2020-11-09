using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sounds : MonoBehaviour
{
    public AudioClip[] bullets;
    public AudioClip[] explosions;
    public   AudioSource player;
    public static Sounds inst;
    void Start()
    {
        inst = this;
        player = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayRandom(string str)
    {
        inst.player.Stop();
        if(inst.player ==null)
            inst.player = inst.GetComponent<AudioSource>();
        int n;
        switch(str)
        {
            case "Bullet": n= Random.Range(0, inst.bullets.Length);
                inst.player.clip = inst.bullets[n];
                inst.player.Play();break;
            case "Explosion":
                n = Random.Range(0, inst.explosions.Length);
                inst.player.clip = inst.explosions[n];
                inst.player.Play(); break;
        }
        
    }
}
