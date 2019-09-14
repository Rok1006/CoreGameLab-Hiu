using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    Vector2 movement;


    public static PlayerMove Instance;
    bool moveRight;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
       //if(moveRight == true)
    }

    void PlayerMoveRight(int distance)
    {
        //make sprite face right
        //transform.Translate(new Vector2(transform.position.x + d, 0) * speed * Time.deltaTime);
    }
    //player move left
    //player move right
    //player jump
    //player do sth like switch off button or sth
    //take the treasure or sth
}
