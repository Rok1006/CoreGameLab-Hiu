using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingPlat : MonoBehaviour
{
    public int score;
    public Text theScore;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        audio = GetComponent<AudioSource>();

        //GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 0f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y); //getting the direction between one object to another

        //transform.up = direction;


        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        if (Input.GetKeyDown(KeyCode.Space)){
            GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 0f, 0.5f, 1f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == ("Ball"))
        {
            audio.Play();

            GameManager.Instance.score++;
            Debug.Log("yup");
   
            //score++;
            // GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        }

    }

}


    //add collision to score}
