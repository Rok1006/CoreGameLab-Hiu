using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool doorShouldOpen;
    public static Ball One;
    public bool playerMove;

    void Awake()
    {
        if (One == null)
        {
            One = this;
            DontDestroyOnLoad(this);
        }
        else if (One != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        doorShouldOpen = false;
        playerMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Instance.gotBall == true)
        {
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
