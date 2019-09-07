using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBall : MonoBehaviour
{
    //[SerializeField] Transform Respawn;
    public float bulletSpeed;
    //float dirX;
    //float dirY;
    Rigidbody2D rb;
    public GameObject start;
    public float max_x;
    public float max_y;
   //public int speed;

    //public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.transform.position = start.transform.position;
        //rb.velocity = Vector2.zero;
        // transform.position = Respawn.transform.position;


    }

    // Update is called once per frame
    void Update()
    { //this makes the ball come back
      //if (Input.GetMouseButtonDown(0))
      //{
      //    //Debug.Log("Clicked" + Input.mousePosition);
      //    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //translate it into actual position
      //    Debug.Log("Clicked" + worldPoint.x + " " + worldPoint.y);

        //    //Vector2 mousePoint = new Vector2(worldPoint.x, worldPoint.y);
        //    Vector3 direction = worldPoint - transform.position;
        //    rb.AddForce(new Vector2(direction.x, direction.y) * bulletSpeed, ForceMode2D.Impulse);
        //}
       
        transform.Rotate(Vector3.forward * -50); //rotate it

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)  //detect between two obj with rigidbody
    {
        Destroy(gameObject);
    }

}
