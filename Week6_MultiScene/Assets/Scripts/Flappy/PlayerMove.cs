using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    public float forceAmount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2(0f, forceAmount);
            //rb.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Jo.score++;
        Debug.Log(GameManager.Jo.score);
        GameManager.Jo.UpdateScore();
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Jo.LoseGame();
    }
}
