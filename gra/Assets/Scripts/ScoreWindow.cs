﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text highscoreText;
    private Text scoreText;
    private void Awake()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();
    }

    private void Start()
    {
        highscoreText.text = "Najlepszy wynik: " + Score.GetHighscore().ToString();
    }
    private void Update()   
    {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
    }
}
