using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingInput : MonoBehaviour
{
    float horz;
    float vert;
    Rigidbody2D rb;
    public float forceAmount;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        //Debug.Log(horz + " " + vert);

        //Get specific Keys : e.g horz + -1f or 1f

       // transform.Translate(horz * Time.deltaTime, vert * Time.deltaTime, 0);
       rb.AddForce(new Vector2(horz, vert)*forceAmount);

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("yup");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("no");
        }
        else if (Input.GetKey(KeyCode.H) || (Input.GetKey(KeyCode.G)))
        {
            Debug.Log("so");
        }

    }
}
