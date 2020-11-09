using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public CanvasGroup can;
    public bool FadeIn;
    public bool fadeOut;
    public Action callBack;

    void Start()
    {
       
    }

    
    void Update()
    {
        if(FadeIn)
        {
            can.alpha += 0.01f;
            if (can.alpha >= 1)
            {
                FadeIn = false;
                callBack?.Invoke();
            }
        }
        if (fadeOut)
        {
            can.alpha -= 0.01f;
            if (can.alpha <= 0)
            {
                fadeOut= false;
                callBack?.Invoke();
            }
        }

    }

    internal void Reset()
    {
        can = GetComponent<CanvasGroup>();
        can.alpha = 0;
    }
}
