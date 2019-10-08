using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManage : MonoBehaviour
{
    public GameObject button;
    public GameObject gate;
    Animator bAnim;
    Animator gAnim;
    public bool buttonHit;
    //public static GateManage Instance;

   
    // Start is called before the first frame update
    void Start()
    {
        bAnim = button.GetComponent<Animator>();
        gAnim = gate.GetComponent<Animator>();

        buttonHit = false;
        gAnim.SetBool("Down", true);
        gAnim.SetBool("Up", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!buttonHit)
        {
            bAnim.SetBool("On", false);
            bAnim.SetBool("Off", true);
        }
        if (buttonHit)
        {
            bAnim.SetBool("On", true);
            bAnim.SetBool("Off", false);
            gAnim.SetBool("Down", false);
            gAnim.SetBool("Up", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            buttonHit = true;
        }
        }
}
