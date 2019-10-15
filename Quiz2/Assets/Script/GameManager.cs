using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public Button B;
    public Text buttonText;
    public Slider SD;
    public int sqSpeed;
    public bool start;

    void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(this);
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SD.maxValue = 5;
        buttonText.text = "(1) Choose a number  (2) Click me";
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            buttonText.text = "(1) Choose a number  (2) Click me";
        }

        if (SD.value > 0)
        {
            buttonText.text = SD.value.ToString();
            start = false;
        }
  


       
        ////


        //SD.value = sqSpeed;

        
    }
    public void ClickB()
    {
        SceneManager.LoadScene(1);  //scene2
        sqSpeed = (int)SD.value;
    }
}
