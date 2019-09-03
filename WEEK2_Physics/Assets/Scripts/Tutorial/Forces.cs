using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forces : MonoBehaviour
{
    Rigidbody2D rb;
    public float forceAmount;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //forceAmount = 5;
        //rb.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);   //apply force at any direction and set in what way fast or slow sudden or whatever (mode: Force/impulse
        rb.AddForce(new Vector2(Random.Range(-1.0f, 1.0f), 1) * forceAmount, ForceMode2D.Impulse);  //give it a float

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) // private for within this script
    {
        Debug.Log("yes");
        Debug.Log("collision!!" + col.gameObject.name);  //get the name of it
        //col.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow; //change the color

        if (col.gameObject.tag == "Plat1")
        {
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

        }
    }
}
