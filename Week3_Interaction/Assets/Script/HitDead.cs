using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDead : MonoBehaviour
{
    [SerializeField] Transform Respawn;
    Animator animator;
    //public Canvas Black;
    //public Image BlackOut;
    //public GameObject Player;
    //Rigidbody2D Rb;

    void Start()
    {
        //animator = BlackOut.GetComponent<Animator>();
        //Black.GetComponent<Canvas>().enabled = false;
        //Player = GameObject.Find("Player");
        //Rb = Player.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        //Black.GetComponent<Canvas>().enabled = false;
        //animator.SetBool("Dead", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Black.GetComponent<Canvas>().enabled = true;
            //animator.SetBool("Dead", true);
            collision.transform.position = Respawn.position;
            PlayerInput.Instance.stop = true;
        }
       
    }
}


