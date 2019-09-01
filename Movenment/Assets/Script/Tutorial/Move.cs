using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   [Header("Values")]
    public GameObject shape;
    Vector2 move;
    public int speed;
    //Rigidbody2D rb;
    public float timer;
    public GameObject circle;

    private float posX;
    private float posY;
    public float freq;  //frequency
    public float amp;    //ampitude



    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //Vector2 velocity = rb.velocity;
        //Debug.Log(transform.position);
        //rb.velocity = new Vector2(10)
        timer = 0;
       shape.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));  //or just transform.position
        //or
        //transform.Translate(new Vector2(10, 0));   //adding value to current value
        circle.transform.position = new Vector2(0, 0);
        freq = 1;
        amp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1)
        {
            Debug.Log(transform.position);
            //transform.Translate(new Vector2(0.5f, 0) * speed * Time.deltaTime);
            shape.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            timer = 0;
        }

        timer += Time.deltaTime;
        //Time.deltaTime = number of time passes between frames
        //Time.time = amount of time pass at the start of the game

        posX = Mathf.Sin(Time.time*freq)* Mathf.Sin(Time.time);
        posY = Mathf.Cos(Time.time * freq) * Mathf.Sin(Time.time);
        //Mathf = a collection of math stuff 
        //increasing the value of freq and amp makes it fruturate differently

        Debug.Log(posX);
        circle.transform.position = new Vector2(posX + transform.position.x, posY + transform.position.y);  //having a sutle movement
        //adding the transform.position.xy makes the center of the ccircle to the square

      

    }
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.name == "Platform")
    //    {
    //        transform.Translate(new Vector2(-0.5f, 0) * speed * Time.deltaTime);
    //    }
    //}
}
