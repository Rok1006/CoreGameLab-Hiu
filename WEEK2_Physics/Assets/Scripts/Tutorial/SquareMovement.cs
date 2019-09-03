using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    Vector2 dir;
    float spinForce;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector2(Random.Range(-5.0f, 1.0f), Random.Range(-5.0f, 1.0f));

        spinForce = Random.Range(1.0f, 20.0f);
        rb.AddForce(dir, ForceMode2D.Impulse);
        rb.AddTorque(spinForce); //make it spin

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
