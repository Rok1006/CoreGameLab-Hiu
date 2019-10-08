using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    bool inFrontOfDoor2;
    public GameObject DoorTwo;
    Animator Door2Anim;
    public GameObject Door2Portal;

    // Start is called before the first frame update
    void Start()
    {
        Door2Anim = DoorTwo.GetComponent<Animator>();
        Door2Anim.SetBool("Close", true);
        Door2Anim.SetBool("Open", false);
        inFrontOfDoor2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inFrontOfDoor2)
        {
            Door2Portal.SetActive(true);
        }
        else
        {
            Door2Portal.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Door2Anim.SetBool("Close", false);
            Door2Anim.SetBool("Open", true);
            inFrontOfDoor2 = true;
        }
    }
}
