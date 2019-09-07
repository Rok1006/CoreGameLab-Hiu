using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 9)
        {
           Score.text = "0" + score.ToString();
        }
        else if(score>99)
        {
            Score.text = score.ToString();
        }
        else
        {
            Score.text = "00" + score.ToString();
        }

        if(score == 15)
        {
            //u win
        }
    }

    }

