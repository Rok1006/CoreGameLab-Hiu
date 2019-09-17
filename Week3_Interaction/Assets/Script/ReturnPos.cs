using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPos : MonoBehaviour
{
    public GameObject FallBlock1;
    public GameObject FallBlock2;
    Rigidbody2D Rb1;
    Rigidbody2D Rb2;

    private float pos1;

    // Start is called before the first frame update
    void Start()
    {
        FallBlock1 = GameObject.FindWithTag("Block1");
        FallBlock2 = GameObject.FindWithTag("Block2");

        Rb1 = FallBlock1.GetComponent<Rigidbody2D>();
        Rb2 = FallBlock2.GetComponent<Rigidbody2D>();
        //FallBlock1.transform.position = new Vector2(-16.03f, -57.74f);
        //FallBlock2.transform.position = new Vector2(-7.07f, -57.74f);
        FallBlock1.transform.position = new Vector2(154.18f, -5.28f);
        FallBlock2.transform.position = new Vector2(163.21f, -5.28f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Block1"))
        {
            FallBlock1.transform.position = new Vector2(154.18f, -5.28f);
            Rb1.velocity = Vector2.zero;
        }
        if (collision.gameObject.tag == ("Block2"))
        {
            FallBlock2.transform.position = new Vector2(163.21f, -5.28f);
            Rb2.velocity = Vector2.zero;
        }
    }
}
