using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    Vector2 dir;
    float spinForce;
    Rigidbody2D rb;
    public ParticleSystem burst;
    public ParticleSystem burst2;
    //public ParticleSystem burst2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector2(Random.Range(-5.0f, 1.0f), Random.Range(-5.0f, 1.0f));

        spinForce = Random.Range(1.0f, 10.0f);
        rb.AddForce(dir, ForceMode2D.Impulse);
        rb.AddTorque(spinForce); //make it spin
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)  //detect between two obj with rigidbody
    {
        //if(collision.gameObject.name == "Ball")
        //{
        if(gameObject.tag == "Bk")
        {
            GameManager.Instance.score++;
            Instantiate(burst, transform.position, Quaternion.identity);
            Destroy(gameObject);
        Debug.Log("Hit");
       }
        if (gameObject.tag == "Wh")
        {
            GameManager.Instance.score +=0;
            Instantiate(burst2, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    


    }
}
