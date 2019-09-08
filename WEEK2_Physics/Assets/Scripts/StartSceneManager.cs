using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public Canvas StartMenu;
    public Canvas instruct;
    [SerializeField] public GameObject particleDot;
    [SerializeField] public Image Title;
    [SerializeField] public Text Starts;


    Animator Anim1;
    Animator Anim2;
    Animator Anim3;



    void Awake()
    {

        StartMenu.GetComponent<Canvas>().enabled = false;
        instruct.GetComponent<Canvas>().enabled = true;
        particleDot.SetActive(false);
        Anim1 = Title.GetComponent<Animator>();
        Anim2 = Starts.GetComponent<Animator>();
        Anim3 = particleDot.GetComponent<Animator>();
        Anim3.SetBool("OnDot", false);
        Anim1.SetBool("OnTitle", false);
        Anim2.SetBool("OnStart", false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartMenu.GetComponent<Canvas>().enabled = true;
        instruct.GetComponent<Canvas>().enabled = false;
        particleDot.SetActive(true);
        Anim3.SetBool("OnDot", true);
        Anim1.SetBool("OnTitle", true);
        Anim2.SetBool("OnStart", true);


    }
}
