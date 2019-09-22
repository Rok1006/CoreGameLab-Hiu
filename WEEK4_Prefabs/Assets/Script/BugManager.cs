using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public bool detected;
    Animator animator;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        //pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(pos.x < 0)  //to the right
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }





        //Follow
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        if (detected)
        {
            animator.SetBool("isAngry", true);
            //get angry
        }
        else
        {
            animator.SetBool("isAngry", false);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            detected = true;
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
   

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detected = false;

        }
    }
}
