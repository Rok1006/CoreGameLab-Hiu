using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWeight : MonoBehaviour
{
    public int weightAdd;
    Animator WAanim;
    public static DetectWeight Instance;
    public bool playerOn;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        WAanim = GetComponent<Animator>();
        playerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(weightAdd >= 2)
        {
            //Debug.Log("up");
            if (playerOn)
            { 
            WAanim.SetBool("MoveUP", true);
                WAanim.SetBool("MoveDown", false);
            }
        }

        if(playerOn == false)
        {
            WAanim.SetBool("MoveDown", true);
            WAanim.SetBool("MoveUP", false);
            //Debug.Log("doing");
            ////WAanim.SetTrigger("Stay");
            ////weightAdd = 0;
        }
        if (weightAdd == 0)
        {
            //WAanim.SetBool("MoveDown", true);
            //WAanim.SetTrigger("MoveDown");
            //WAanim.SetTrigger("Stay");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "2KG")
        {
            weightAdd += 1;
        

        }
     }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerOn = true;
        }
    }
}
