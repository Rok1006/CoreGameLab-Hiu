﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //score++;
        //Debug.Log(score);
    }

    public void Click() {
        score++;
        UpdateScoreText(score);
        Debug.Log(score);

    }
    public void ClickDecreaseScore()
    {
        score--;
        UpdateScoreText(score);
        Debug.Log(score);

    }
    void UpdateScoreText(int t) {
        scoreText.text = score.ToString();
    }

}
