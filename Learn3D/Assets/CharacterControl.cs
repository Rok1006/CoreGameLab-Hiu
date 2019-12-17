using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Animator anim;
    float h;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("jump");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetTrigger("Idle");
        }

        h = Input.GetAxis("Horizontal")*3;
        transform.Rotate(0, h, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("run");
        }
    
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetTrigger("Idle");
        }
    }
}
