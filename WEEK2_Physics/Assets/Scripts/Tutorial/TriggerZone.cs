using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    Rigidbody2D rb;
    public float forceAmount;

    public GameObject Planet;
    Vector3 planet_pos;
    Vector3 dir;
    public GameObject[] planets = new GameObject[4];  //using array is fixed while list is dynamic, check internet
    Vector3 direction;    //check which planet is closest
    float distance;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        planet_pos = Planet.transform.position;
        rb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
        distance = Vector3.Distance(planets[0].transform.position, transform.position);
        planet_pos = planets[0].transform.position;

    }

    // Update is called once per frame
    void Update()
    {



        foreach (GameObject p in planets)
        {
            float disCheck = Vector3.Distance(Planet.transform.position, transform.position);
            if(disCheck < distance)
            {
                planet_pos = Planet.transform.position;
                distance = disCheck;
            }
        } //loop on each array items
        //direction = planet_pos - transform.position;
        //rb.AddForce(direction * forceAmount);




        direction = planet_pos - transform.position;
        rb.AddForce(direction * forceAmount);
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       //rb.AddForce(Vector2.up * forceAmount);   //just change the vector 2.up to a set area e.g(1.0f,-1.0)
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(transform.position);
    }
}
