using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlat : MonoBehaviour
{


    [Header("FlipPlat1")]
    public GameObject FP1;
    Animator flip1Anim;
    public float fliptimer;
    public float returntimer;
    public bool count;

    [Header("FlipPlat2")]
    public GameObject FP2;
    Animator flip2Anim;
    public float flip2timer;
    public float return2timer;
    public bool count2;

    AudioSource flip;
    // Start is called before the first frame update
    void Start()
    {
        fliptimer = 0;
        returntimer = 0;
        count = true;
        flip1Anim = FP1.GetComponent<Animator>();
        flip1Anim.SetTrigger("Stay");

        flip2timer = 0;
        return2timer = 0;
        count2 = true;
        flip2Anim = FP2.GetComponent<Animator>();
        flip2Anim.SetTrigger("Stay");

        AudioSource[] audios = GetComponents<AudioSource>();
        flip = audios[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (count)
        {
            fliptimer += Time.deltaTime;
            if (fliptimer >= 7)
            {
                flip1Anim.SetTrigger("Flip");
                flip.Play();
                //fliptimer = 0;
                count = false;
            }
        }
        if (count == false)
        {
            returntimer += Time.deltaTime;
        }


        if (returntimer >= 2)
        {
            flip1Anim.SetTrigger("Return");
            flip.Play();
            flip1Anim.SetTrigger("Stay");
            fliptimer = 0;
            returntimer = 0;
            count = true;
        }

        ///////////////////////////////////////////////////////
        if (count2)
        {
            flip2timer += Time.deltaTime;
            if (flip2timer >= 5)
            {
                flip2Anim.SetTrigger("Flip");
                flip.Play();
                //fliptimer = 0;
                count2 = false;
            }
        }
        if (count2 == false)
        {
            return2timer += Time.deltaTime;
        }


        if (return2timer >= 2)
        {
            flip2Anim.SetTrigger("Return");
            flip.Play();
            flip2Anim.SetTrigger("Stay");
            flip2timer = 0;
            return2timer = 0;
            count2 = true;
        }
    }
}
