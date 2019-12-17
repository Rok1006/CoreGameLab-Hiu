using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource swing;
    AudioSource elevate;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSource[] audios = GetComponents<AudioSource>();
        swing = GetComponent<AudioSource>();
        elevate = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swing()
    {
        swing.Play();
    }

    public void Elevate()
    {
       elevate.Play();
    }
}
