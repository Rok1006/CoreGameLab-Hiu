using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    Rigidbody2D rb;
    //public GameObject sq;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked" + Input.mousePosition);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //translate it into actual position
            Debug.Log("Clicked" + worldPoint.x + " " + worldPoint.y);

            //Vector2 mousePoint = new Vector2(worldPoint.x, worldPoint.y);
            Vector3 direction = worldPoint - transform.position;
            rb.AddForce(new Vector2(direction.x, direction.y), ForceMode2D.Impulse);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)  //detect between two obj with rigidbody
    {
       
            Destroy(collision.gameObject);

    }
}
