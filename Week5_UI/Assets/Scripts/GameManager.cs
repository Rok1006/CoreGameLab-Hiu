using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text time;
    public float timeStart1 = 12;
    public float timeStart2;
    public float timer1;
    public float timer2;

    public InputField inputField;
    public Text textDisplay;
    public Button Enter;
    public string command;
    public Canvas LogIn;
    public GameObject AppManager;

    public InputField secretInputField;
    public string pass;

    public Canvas End;
    AudioSource Success;
    public GameObject sound;
    bool succeed;


    // public float timer;
    void Awake()
    {
        timeStart2 = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //timeStart2 = 0;
        time.text = timeStart1.ToString() + "00" + timeStart2.ToString() + "PM";

        timer1 = 0;
        timer2 = 0;
        LogIn.GetComponent<Canvas>().enabled = true;
        End.GetComponent<Canvas>().enabled = false;
        AppManager.SetActive(false);
        Success = sound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(succeed == true)
        {
            Success.Play();
        }


        command = inputField.text;
        //command = "PASSWORD";
        pass = secretInputField.text;

        if(pass == "1215")
        {
            Debug.Log("Bingo");
            End.GetComponent<Canvas>().enabled = true;
            //Success.Play();
            succeed = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        time.text = timeStart1.ToString() + "00" + timeStart2.ToString() + "PM";
        timer1 += Time.deltaTime;
        //if (timer1 > 60) 
        //{
        //    timeStart1++;
        //    timer1 = 0;
        //}
        if (timeStart2 > 60 )  //00:
        {
            timeStart1++;
        }

        timer2 += Time.deltaTime;
        if (timer2 > 30)  //:00
        {
            timeStart2+=5;
            timer2 = 0;
           //timeStart2 = 0;
        }

        if (timeStart2 > 9)
        {
           time.text = Mathf.Round(timeStart1).ToString() + ":" + Mathf.Round(timeStart2).ToString() + "PM";
        }else if (timeStart2 < 10) {
            time.text = Mathf.Round(timeStart1).ToString() + ":0" + Mathf.Round(timeStart2).ToString() + "PM";

        }

    }

    public void CloseLogIn() {
        LogIn.GetComponent<Canvas>().enabled = false;
        AppManager.SetActive(true);
    }

}
