using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public Text Score;
    public Canvas Instruct;
    public Canvas ScoreShow;
    public GameObject spawn1;
    public string sceneName;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        score = 0;
        Instruct.GetComponent<Canvas>().enabled = true;
        ScoreShow.GetComponent<Canvas>().enabled = false;
        spawn1.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instruct.GetComponent<Canvas>().enabled = false;
            ScoreShow.GetComponent<Canvas>().enabled = true;
            spawn1.SetActive(true);

        }



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
    public void Menu()
    {
        SceneManager.LoadScene(sceneName);
    }

}

