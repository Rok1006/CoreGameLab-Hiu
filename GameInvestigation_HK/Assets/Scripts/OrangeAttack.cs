using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeAttack : MonoBehaviour
{
    Rigidbody2D Rb;
    float distance;
    public GameObject Player;
    public float speed;
    Vector3 pos;
    Vector3 dir;
    bool left;
    bool right;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        left = false;
        right = false;

       if(Player.transform.position.x>0)
        {
            right = true;
            left = false;
        }
        if (Player.transform.position.x < 0)
        {
            left = true;
            right = false;
        }
    }
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        if (left)
        {
            Rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            Rb.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
            Rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        }
        if (right)
        {
            Rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            Rb.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            Rb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        dir = Player.transform.position - transform.position;
        dir = dir.normalized;
        Rb.AddForce(dir * speed);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);

        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

        }
    }
}
