using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    Rigidbody2D rb;
    public bool IsGravDown;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        IsGravDown = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGravDown) //isDown
        {
            rb.gravityScale = 1;
        }
        else
        {
            rb.gravityScale = -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGravDown = !IsGravDown;
        //if (collision.gameObject.CompareTag("Plat1"))
        //{

        //}
    }
}
