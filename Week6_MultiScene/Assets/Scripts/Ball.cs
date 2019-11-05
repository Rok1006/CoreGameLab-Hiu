using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public bool doorShouldOpen;
    public static Ball One;
    public bool playerMove;
    public bool openwithball;
    public static Ball Instance;
    public Image ballsignifier;
    public bool ballshow;

    void Awake()
    {
        //if (One == null)
        //{
        //    One = this;
        //    DontDestroyOnLoad(this);
        //}
        //else if (One != this)
        //{
        //    Destroy(gameObject);
        //}
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        doorShouldOpen = false;
        playerMove = false;
        openwithball = false;
        ballsignifier.enabled = false;
        ballshow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(openwithball == true)
        {
            ballsignifier.enabled = true;
            ballshow = true;
            doorShouldOpen = true;
        }
        if(Player.Instance.goBack == true)
        {
            playerMove = true;
        }
    }
    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {

    //    }
    //}
}
