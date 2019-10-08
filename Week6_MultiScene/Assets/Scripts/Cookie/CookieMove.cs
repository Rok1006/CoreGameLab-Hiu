using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieMove : MonoBehaviour
{
    float horz;
    public float speed;
    bool canJump;
    int jumpAllowed;
    int jumps;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //horz = Input.GetAxis("Horizontal");
        rb = GetComponent<Rigidbody2D>();
        jumpAllowed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horz * speed * Time.deltaTime);

        if (canJump)
        {
            if (jumps < jumpAllowed)
            {



                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                    jumps++;
                }
            }
            else
            {
                canJump = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            jumps = 0;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Upgrade")
        {
            jumpAllowed = 2;
            Destroy(collision.gameObject);
        }
    }
}
