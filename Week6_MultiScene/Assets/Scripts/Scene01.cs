using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene01 : MonoBehaviour
{
    public GameObject Player;
    public GameObject ball;
   public Canvas Instruct;
    //public bool backInPos;
    public Canvas word;


    public GameObject Door1Portal;
    public Canvas Win;
     public GameObject Door1;
    Animator Door1Anim;
    public bool door1Open;
    public static Scene01 Instance;
    public bool changeRespawn;
    public Image ballsignifier;
   
   void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //backInPos = false;
        //if (backInPos)
        //{
        //    Player.transform.position = new Vector2(85.2f, -4.13f);
        //    ball.transform.position = new Vector2(76.61f, -6.68f);
        //}
        Instruct.GetComponent<Canvas>().enabled = true;
        Door1Anim = Door1.GetComponent<Animator>();

        Debug.Log("Move!");
        door1Open = false;
        ballsignifier.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instruct.GetComponent<Canvas>().enabled = false;
            // Destroy(Instruct);

        }

        if (GameManage.Vill.backInPos == true)
        {
            //backInPos = true;
            Instruct.GetComponent<Canvas>().enabled = false;
            word.GetComponent<Canvas>().enabled = false;

        }

        if (GameManage.Vill.backInPos == true)
        {
            Debug.Log("yes");
            Player.transform.position = new Vector2(85.2f, -4.13f);
            ball.transform.position = new Vector2(76.61f, -6.68f);
            changeRespawn = true;
            GameManage.Vill.backInPos = false;
            Ball.One.playerMove = false;
  
            //Respawn.Instance.RespawntoRight = true;
            //Respawn.Instance.RespawntoLeft = false;  //
        }
        if (GameManage.Vill.showIt == true)
        {
            ballsignifier.enabled = true;
            GameManage.Vill.showIt = false;
        }
        if (GameManage.Vill.doorwillopen == true)
        {
            door1Open = true;
        }
        if (GameManage.Vill.Instructshouldclose == true)
        {
            Instruct.GetComponent<Canvas>().enabled = false;
        }

        if (door1Open == false)
        {
            //Debug.Log("not opened");
            Door1Anim.SetBool("Close", true);
            Door1Anim.SetBool("Open", false);
            Door1Portal.SetActive(false);
        }
        if (door1Open)
        {
            //Debug.Log("why is it opened");
            Door1Anim.SetBool("Close", false);
            Door1Anim.SetBool("Open", true);
            Door1Portal.SetActive(true);

        }

    }
}
