using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    private FadeManager fm;
    public int score;
    private static Game inst;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        inst = this;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal static void StartGame()
    {
        FadeManager.FadeIn("Author", () =>
        {
            FadeManager.FadeIn("Player", () =>
            {
                FadeManager.FadeOUT("Author", null);
                FadeManager.FadeOUT("Player", null);
                FadeManager.FadeIn("Score", null);
            });
        });
    }

    internal static void IncreaseScore()
    {
        int n = Random.Range(10, 100);
        inst.score += n;
        inst.scoreText.text = inst.score.ToString();
    }
}
