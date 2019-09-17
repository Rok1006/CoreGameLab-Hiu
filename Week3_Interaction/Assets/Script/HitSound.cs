using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    private AudioSource audio1;
    //public GameObject Ground;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        //Ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        //audio.Play();
        //Debug.Log("hit");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("hit");
            audio1.Play();
        }
    }
}
