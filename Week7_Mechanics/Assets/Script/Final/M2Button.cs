using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M2Button : MonoBehaviour
{
    public GameObject M2B;
   // public Button m2b;
    Animator m2bAnim;
    public bool Inside;

    public GameObject OnOff;
    Animator M2Anim;
    public bool machine2off;
    AudioSource machineOff;

    // Start is called before the first frame update
    void Start()
    {
        m2bAnim = M2B.GetComponent<Animator>();
        m2bAnim.SetTrigger("Stay");
        Inside = false;
        M2Anim = OnOff.GetComponent<Animator>();
        //machine1off = false;
        AudioSource[] audios = GetComponents<AudioSource>();
        machineOff = audios[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Inside)
        {
            if (Input.GetKey(KeyCode.F))
            {
                m2bAnim.SetTrigger("Press");
                m2bAnim.SetTrigger("Gone");
                //do sth
                MachineManager.Instance.Machine2Finished = true;
                machineOff.Play();
            }
        }
        //if (machine1off)
        //{
        //    if (m1bAnim.GetCurrentAnimatorStateInfo(0).IsName("M1Gone"))
        //    {

        //        M1Anim.SetTrigger("Off");
        //        MachineManager.Instance.Machine1Finished = true;
        //    }
        //}
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (MachineManager.Instance.Machine1Finished==true)   //if turn off machine 1
            {
                //Debug.Log("what");
                m2bAnim.SetTrigger("Appear");
                Inside = true;
           }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            m2bAnim.SetTrigger("Disappear");
        }
    }
}
