using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAttack : MonoBehaviour
{
    Rigidbody2D rb;
    public int attackSpeed;
    public GameObject player;
    public GameObject burst;

    public BugManager bm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        bm = GameObject.FindGameObjectWithTag
("Bug").GetComponent<BugManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Time.deltaTime * attackSpeed;
        //rb.AddForce(Vector2.right * attackSpeed);

        if(bm.left == true) 
        {
            Debug.Log("yes");
            rb.AddForce(Vector2.left * attackSpeed );

        }
        if (bm.right == true)
        {
            rb.AddForce(Vector2.right * attackSpeed);

        }


        //rb.AddForce(new Vector2(Random.Range(-17f, 17f), Random.Range(-11f, 11f)) * attackSpeed);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bound")
        {
           Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(burst, transform.position, Quaternion.identity);
            Destroy(gameObject);
            //Destroy(burst);
            //sound
            //reduce health

        }
    }
}
