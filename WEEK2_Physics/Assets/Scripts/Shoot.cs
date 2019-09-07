using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject startPos;
    //Rigidbody Rb;
    public float bulletSpeed;
    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
       //ball = ballPrefab.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(ballPrefab, startPos.transform.position, Quaternion.identity);
            //Rb.velocity = Vector2.zero;
            //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //translate it into actual position
            //Debug.Log("Clicked" + worldPoint.x + " " + worldPoint.y);

            ////no//Vector2 mousePoint = new Vector2(worldPoint.x, worldPoint.y);
            //Vector3 direction = worldPoint - transform.position;
            ////Rb.AddForce(new Vector2(direction.x, direction.y) * bulletSpeed);
            //Rb.velocity = direction * bulletSpeed;
            //
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - startPos.transform.position));
            direction.Normalize();
            // Creates the bullet locally
            GameObject ball = (GameObject)Instantiate(
                                    ballPrefab,
                                    startPos.transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);
            // Adds velocity to the bullet
            ball.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        }
    }
}
