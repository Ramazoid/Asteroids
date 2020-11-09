using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Dictionary<string, Fader> faders;
    private static FadeManager inst;

    void Start()
    {
        
        faders = new Dictionary<string, Fader>();
        inst = this;
        Fader[] fs = GameObject.FindObjectsOfType<Fader>();
        foreach (Fader f in fs)
        {
            faders.Add(f.name, f);
            f.Reset();
        }
    }

    internal static void FadeOUT(string fadername, Action callBack)
    {

        Fader f = GetFaderByName(fadername);
        if (f != null)
        {
            f.callBack = callBack;

            f.fadeOut = true;
        }
    }



    internal static void FadeIn(string fadername, Action callBack)
        {
            Fader f = GetFaderByName(fadername);
            if (f != null)
            {
                f.callBack = callBack;

                f.FadeIn = true;
            }

        }

    private static Fader GetFaderByName(string fadername)
    {
        if (inst.faders.ContainsKey(fadername))
            return inst.faders[fadername];


        throw new Exception($"Fader<color=red> [{fadername}]</color> not found!!!!");
    }
}
