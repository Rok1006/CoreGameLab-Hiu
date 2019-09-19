using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
   public GameObject one;

    private void Awake()
    {
        //Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //theScore.text = score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
        if (collision.gameObject.tag == ("1"))
        {
            Debug.Log("yup");
            //score++;
            // GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = one.GetComponent<Renderer>().material.color;
        }
    }

}
