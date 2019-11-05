using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject OL;
    public GameObject OR;
    public GameObject LDoor;
    public GameObject RDoor;
    public GameObject LTrigger;
    public GameObject RTrigger;
    Animator LDAnim;
    Animator RDAnim;
    int enterCount;

    public Canvas Instruct;
    public Canvas TitleScreen;
    public GameObject title;
    public GameObject button;
    Animator titleAnim;
    Animator buttonAnim;
    public string sceneName;
    public GameObject Layout;
    bool load;

    public static StartManager Instance;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        LDAnim = LDoor.GetComponent<Animator>();
        RDAnim = RDoor.GetComponent<Animator>();

        titleAnim = title.GetComponent<Animator>();
        buttonAnim = button.GetComponent<Animator>();
        LDAnim.SetBool("open", true);
        RDAnim.SetBool("open", true);
        enterCount = 0;
        Instruct.GetComponent<Canvas>().enabled = true;
        TitleScreen.GetComponent<Canvas>().enabled = false;
        load = false;
        GameManage.Vill.backInPos = false;
    }
    public void ClickStart()
    {
        Instruct.GetComponent<Canvas>().enabled = true;
        SceneManager.LoadScene(sceneName);
        //Instantiate(Layout,)
        GameManage.Vill.backInPos = false;
        HealthManager.Vill.ToStart();
        HealthManager.Vill.addHeart = true;
        HealthManager.Vill.restart = true;
        for (int i = 0; i < HealthManager.Vill.slot.Length; i++)
        {
            HealthManager.Vill.slot[i].SetActive(true);
        }
        HealthManager.Vill.die = 0;
        //load = true;
    }
    // Update is called once per frame
    void Update()
    {
        //if (load)
        //{
        //    //SceneManager.LoadScene(0);
        //    load = false;
        //}
        //GameManage.Vill.backInPos = false;
        //GameManage.Vill.Instructshouldclose = false;


        if (enterCount == 1)
        {
           //Debug.Log("Working");
            LDAnim.SetBool("open", false);
            RDAnim.SetBool("open", false);
            LTrigger.SetActive(false);
            RTrigger.SetActive(false);
            Instruct.GetComponent<Canvas>().enabled = false;
            TitleScreen.GetComponent<Canvas>().enabled = true;
            titleAnim.SetBool("Appear", true);
            buttonAnim.SetBool("Appear", true);
        }
        GameManage.Vill.backInPos = false;
        GameManage.Vill.Instructshouldclose = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "LDoor")
        {
            transform.position = OL.transform.position;
            enterCount++;
        }
        if (collision.gameObject.tag == "RDoor")
        {
            transform.position = OR.transform.position;
            enterCount++;
        }
    }
}
