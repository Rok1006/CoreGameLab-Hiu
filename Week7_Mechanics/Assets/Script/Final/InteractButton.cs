using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public Button Interact;
    public GameObject Inter;
    Animator interAnim;
    public bool interAvailable;
    public GameObject DialogueBox;
    Animator DiaAnim;

    // Start is called before the first frame update
    void Start()
    {
        interAnim = Interact.GetComponent<Animator>();
        Inter.SetActive(false);
        interAvailable = true;
        //DialogueBox.SetActive(false);
        DiaAnim = DialogueBox.GetComponent<Animator>();
        //DiaAnim.SetTrigger("S")
    }

    // Update is called once per frame
    void Update()
    {
        if (interAnim.GetCurrentAnimatorStateInfo(0).IsName("Interact"))
        {
           //Debug.Log("Finished");

            if (interAvailable == false)
            {
                Inter.SetActive(false);
            }
        }
    }

    public void ClickInteract()
    {
        interAnim.SetTrigger("Press");
        interAvailable = false;
        DiaAnim.SetTrigger("Show");
        //DialogueBox.SetActive(true);
        //Inter.SetActive(false);
        //conver count++;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (interAvailable)
        {
            if (col.gameObject.tag == "Player")
            {
                Inter.SetActive(true);
                interAnim.SetTrigger("Appear");
            }
        }
        //else
      


    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (interAvailable)
        {
            if (col.gameObject.tag == "Player")
            {
                interAnim.SetTrigger("Disappear");
                interAnim.SetTrigger("Stay");

            }
        }
     

    }
}
