using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M1Button : MonoBehaviour
{
    public GameObject M1B;
    public Button m1b;
    Animator m1bAnim;
    public bool Inside;

    public GameObject OnOff;
    Animator M1Anim;
    public bool machine1off;

    AudioSource machineWorking;
    AudioSource machineOff;

    // Start is called before the first frame update
    void Start()
    {
        m1bAnim = M1B.GetComponent<Animator>();
        m1bAnim.SetTrigger("Stay");
        Inside = false;
        M1Anim = OnOff.GetComponent<Animator>();
        machine1off = false;

        AudioSource[] audios = GetComponents<AudioSource>();
        machineWorking = audios[0];
        machineOff = audios[1];

        //machineWorking.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Inside)
        {
            if (Input.GetKey(KeyCode.F))
            {
                m1bAnim.SetTrigger("Press");
                m1bAnim.SetTrigger("Gone");
                //do sth
                machine1off = true;
                //machineWorking.Stop();
                machineOff.Play();
            }
        }

        if (machine1off)
        {
            if (m1bAnim.GetCurrentAnimatorStateInfo(0).IsName("M1Gone"))
            {

                M1Anim.SetTrigger("Off");
                MachineManager.Instance.Machine1Finished = true;
}
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            if (CompoCollect.Instance.objectCount == 3)   //change to 3
            {
                Debug.Log("what");
                m1bAnim.SetTrigger("Appear");
                Inside = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            m1bAnim.SetTrigger("Disappear");
        }
    }
}
