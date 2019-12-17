using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rb;
    bool normal;
    bool higher;
    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        normal = false;
        higher = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.S))
        //{
        //    if (Input.GetKey(KeyCode.F))
        //    {
        //        higher = true;
        //    }
        //}
        //else
        //{
        //    higher = false;
        //}

        //if (normal)
        //{
        //    higher = false;
        //    rb.AddForce(new Vector2(0, 500));
        //}
        //if (higher) {
        //    normal = false;
        //    rb.AddForce(new Vector2(0, 1000));
        //}

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("yup");
            normal = true;

            if (normal)
            {
                rb.AddForce(new Vector2(0, 500));
            }
       
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.F))
                {
                    normal = false;
                    rb.AddForce(new Vector2(0, 700));
                }
            }
            else
            {
                normal = true;
            }

        }
    }
}
