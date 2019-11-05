using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthManager : MonoBehaviour
{
    public GameObject[] slot;
    public GameObject heart;  //prefab
    public bool[] full;
    public bool addHeart;
    public static HealthManager Vill;
    AudioSource explode;
    public GameObject heartbeat;
    public int loseheart;
    public int die;
    public Canvas Lose;
    public bool lose;
    public bool restart;
    public GameObject Layout;


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
      
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        ToStart();

        //addHeart = true;
        //explode = GetComponent<AudioSource>();
        //lose = false;
        //Lose.GetComponent<Canvas>().enabled = false;
        //for (int i = 0; i < slot.Length; i++)
        //{
        //    Debug.Log("yo");
        //    if (full[i] == false)
        //    {
        //        Instantiate(heart, slot[i].transform, false);
        //        full[i] = true;
        //        break;
        //    }
        //}
    }
    public void ToStart()
    {
        addHeart = true;
        explode = GetComponent<AudioSource>();
        lose = false;
        //Lose.GetComponent<Canvas>().enabled = false;
        //for (int i = 0; i < slot.Length; i++)
        //{
        //    slot[i].SetActive(true);
        //}
        }
    // Update is called once per frame
    void Update()
    {
        if (addHeart)
        {
            for (int i = 0; i < slot.Length; i++)
            {
                //Debug.Log("yo");
                if (full[i] == false)
                {
                    Instantiate(heart, slot[i].transform, false);
                    full[i] = true;
                    //break;
                }
            
            }
            addHeart = false;
        }

        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[0] == null)
            {
                loseheart=3;
                break;

            }
            if (slot[1] == null)
            {
                loseheart=2;
                break;

            }
            if (slot[2] == null)
            {
                loseheart=1;
                break;

            }

        }
   
        if (loseheart == 3)
        {
            heartbeat.GetComponent<AudioSource>().Stop();
            //its stopping only one
            //Lose.GetComponent<Canvas>().enabled = true;
        }
        if (restart)
        {
            ToStart();
            restart = false;
        }
        //Lose.GetComponent<Canvas>().enabled = false;
        if (die >= 3)
        //{
            //Debug.Log("youdied");
            //Lose.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                Lose.GetComponent<Canvas>().enabled = false;
                die = 0;
               //Destroy(DontDestroy.Vill.gameObject);  //try not to destroy it
                //Destroy(gameObject);   //but the thing inside is gone
            }
            //Time.timeScale = 0;
        }

    }
