using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float posX;
    public float posY;
    public GameObject MovingBlock;
    Animator anim;
    public float timer;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(transform.position);
        transform.position = new Vector2(posX, posY);  
        anim = MovingBlock.GetComponent<Animator>();
        anim.speed = 0; //start at 0
        timer = 0;


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3) //every three seconds
        {
            Debug.Log("Faster");
            anim.speed += 0.2f;
            timer = 0;
        }
        if(anim.speed >= 2)
        {
            anim.speed = 0; //becomes slow again
        }
        //anim.speed = 2;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Trigger") 
        {
            Debug.Log("Entered");
            rb.velocity = Vector2.zero; //pause
            transform.position = new Vector2(posX, posY);
        }

    }
}
