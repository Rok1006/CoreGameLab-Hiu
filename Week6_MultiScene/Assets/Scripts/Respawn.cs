using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    private HealthManager healthManager;

    public GameObject ResPtLeft;
    public GameObject ResPtRight;
    public GameObject ResPt;
    public GameObject Player;
    //public int die;
    public Canvas Lose;
   public static Respawn Instance;
    AudioSource fail;
    public bool RespawntoRight;
    public bool RespawntoLeft;
    public GameObject ball;

    void Awake()
    {
        Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        Lose.GetComponent<Canvas>().enabled = false;
        fail = GetComponent<AudioSource>();
        healthManager = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthManager>();
        RespawntoRight = false;
        RespawntoLeft = true;
  
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthManager.Vill.die == 3)
        {
            GameManage.Vill.backInPos = false;
            GameManage.Vill.Instructshouldclose = false;
            Lose.GetComponent<Canvas>().enabled = true;

        }
        if (Scene01.Instance.changeRespawn == true)
        {
            RespawntoRight = true;
            RespawntoLeft = false;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (RespawntoRight)
            {
                Player.transform.position = ResPtRight.transform.position;
                ball.transform.position = new Vector2(76.61f, -6.68f);
            }
            if (RespawntoLeft)
            {
                Player.transform.position = ResPtLeft.transform.position;
            }
            //Player.transform.position = ResPtLeft.transform.position;
            fail.Play();
            HealthManager.Vill.die++;
            for (int i = healthManager.slot.Length-1; i >= 0; i--)
            {
                if (healthManager.full[i] == true)
                {
                    Debug.Log("yo");
                    //Destroy(healthManager.slot[i]);
                    healthManager.slot[i].SetActive(false);
                    healthManager.GetComponent<AudioSource>().Play();
                    healthManager.full[i] = false; 
                    break;
                }
               
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if (RespawntoRight)
            //{
            //    Player.transform.position = ResPtRight.transform.position;
            //}
            //if (RespawntoLeft)
            //{
            //    Player.transform.position = ResPtLeft.transform.position;
            //}
            Player.transform.position = ResPt.transform.position;
            HealthManager.Vill.die++;
            fail.Play();
            for (int i = healthManager.slot.Length - 1; i >= 0; i--)
            {
                if (healthManager.full[i] == true)
                {
                    Debug.Log("yo");
                    //Destroy(healthManager.slot[i]);
                    healthManager.slot[i].SetActive(false);
                    healthManager.GetComponent<AudioSource>().Play();
                    healthManager.full[i] = false;
                    break;
                }

            }
        }
    }
}
