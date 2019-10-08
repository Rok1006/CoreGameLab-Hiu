using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Jo;
    public int score;

    void Awake()
    {
        if(Jo == null) {
            Jo = this;
            DontDestroyOnLoad(this);
           }
        else if(Jo != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score == 3)
        {
            score = 4;
            UpdateScore();
            SceneManager.LoadScene(2);
        }
    }
    public void UpdateScore()
    {
        Debug.Log(score);
        UIManager.vill.ShowNewScore(score);
    }

    public void LoseGame()
    {
        SceneManager.LoadScene(3);
        score = 0;
        UpdateScore();
    }
}
