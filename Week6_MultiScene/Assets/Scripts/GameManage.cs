using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public static GameManage Vill;
    public GameObject Door1;
    public GameObject Player;
    public GameObject ball;


    Animator Door1Anim;

    bool door1Open;
    public GameObject Door1Portal;
    public Canvas Win;
    public Canvas Instruct;
   public bool backInPos;




    void Awake()
    {
        if (Vill == null)
        {
            Vill = this;
            DontDestroyOnLoad(this);
        }
        else if (Vill != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Door1Anim = Door1.GetComponent<Animator>();

        Debug.Log("Move!");
        door1Open = false;
        backInPos = false;
        //Ball.One.playerMove = true;
        if (backInPos == true)
        {
            Debug.Log("Move!");
            Player.transform.position = new Vector2(85.2f, -4.13f);
            ball.transform.position = new Vector2(76.61f, -6.68f);
            Instruct.GetComponent<Canvas>().enabled = false;
        }
        Time.timeScale = 1;
        //Instruct.GetComponent<Canvas>().enabled = true;
    }
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           Instruct.GetComponent<Canvas>().enabled = false;
           // Destroy(Instruct);

        }
            if (!door1Open)
        {
            Door1Anim.SetBool("Close", true);
            Door1Anim.SetBool("Open", false);
            Door1Portal.SetActive(false);
        }
        if (door1Open)
        {
            Door1Anim.SetBool("Close", false);
            Door1Anim.SetBool("Open", true);
            Door1Portal.SetActive(true);

        }

        if (Ball.One.doorShouldOpen == true)
        {
            door1Open = true;
        }

        if (Ball.One.playerMove == true)
        {
            backInPos = true;
            Instruct.GetComponent<Canvas>().enabled = false;

        }
        if (backInPos)
        {
            Debug.Log("Move!");
            //Player.transform.position = new Vector2(85.2f, -4.13f);
            //ball.transform.position = new Vector2(76.61f, -6.68f);
            //Instruct.GetComponent<Canvas>().enabled = false;
            //Ball.One.playerMove = false;

        }
        //if (Ball.One.playerMove == true)
        //{
        //    Debug.Log("Move!");
        //}
        //void Door1Open(bool open)
        //{
        //    Door1Anim.SetBool("Close", false);
        //    Door1Anim.SetBool("Open", true);
        //}
    }
}