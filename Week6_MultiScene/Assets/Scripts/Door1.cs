using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Door1 : MonoBehaviour
{
    public Canvas Win;
    AudioSource win;
    // Start is called before the first frame update
    void Start()
    {
        Win.GetComponent<Canvas>().enabled = false;
       win = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       //Win.GetComponent<Canvas>().enabled = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Win.GetComponent<Canvas>().enabled = true;
            win.Play();
        }
    }
}
