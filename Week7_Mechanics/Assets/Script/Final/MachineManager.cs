using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MachineManager : MonoBehaviour
{
    public bool Machine1Finished;
    public bool Machine2Finished;
    public bool ShowTime;
    public GameObject DialogueBox;
    Animator DiaAnim;
    public static MachineManager Instance;

    public bool AlarmUp;
    public GameObject Alarm;
    Animator AlarmAnim;

    public float timeStart = 10;
    public GameObject CountDown;
    public Text cd;
    public bool startCount;


    public Canvas Win;
    public Canvas Lose;
    public Canvas StartDis;
    public GameObject Lost;
    //audio
    AudioSource alarm;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Machine1Finished = false;
        Machine2Finished = false;
        ShowTime = false;
        DiaAnim = DialogueBox.GetComponent<Animator>();
        AlarmUp = false;
        AlarmAnim = Alarm.GetComponent<Animator>();
        CountDown.SetActive(false);
       // cd.text = "REMAINING TIME: " + timeStart.ToString();
        startCount = false;

        Win.GetComponent<Canvas>().enabled = false;
        Lose.GetComponent<Canvas>().enabled = false;
        StartDis.GetComponent<Canvas>().enabled = true;

       alarm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Machine1Finished)
        {
            //DiaAnim.SetTrigger("Show");
            //DiaAnim.SetBool("Appear", true);
            //DiaAnim.SetBool("Disappear", false);
            AlarmUp = true;
        }

        if (AlarmUp)
        {
            AlarmAnim.SetTrigger("Ring");
            alarm.Play();
            ShowTime = true;
        }

        if(Machine2Finished == true)
        {
            AlarmAnim.SetTrigger("Stay");
            alarm.Stop();
            // win Ui
            Win.GetComponent<Canvas>().enabled = true;
        }
        if (ShowTime)
        {
            CountDown.SetActive(true);
            startCount = true;
        }
        if (startCount == true)
        {
            timeStart -= Time.deltaTime;
            cd.text = "REMAINING TIME: " + Mathf.Round(timeStart).ToString();
        }
        ///////////////////////////////////////////

        if (timeStart < 0)
        {
            //lost UI
            Lose.GetComponent<Canvas>().enabled = true;
        }

        if (Lose.GetComponent<Canvas>().enabled == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKey(KeyCode.RightCommand))
            {
                //go to menu
                        SceneManager.LoadScene(0);
            }
        }
        if (Win.GetComponent<Canvas>().enabled == true)
        {
            Lost.SetActive(false);
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKey(KeyCode.RightCommand))
            {
                //go to menu
                 SceneManager.LoadScene(0);
            }
        }
        if (StartDis.GetComponent<Canvas>().enabled == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartDis.GetComponent<Canvas>().enabled = false;
            }
          
        }
    }
}
