using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager vill;
    public Text scoreText;

    void Awake()
    {
        if (vill == null)
        {
            vill = this;
            DontDestroyOnLoad(this);
        }
        else if (vill != this)
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
        
    }
    public void ShowNewScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
