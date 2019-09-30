using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject heart;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = heart.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggle() 
    {
        //bool toggleVal = 
        ////anim.GetBool(GetComponent<Toggle>().isOn);
        //anim.SetBool(GetComponent<Toggle>().isOn);
    }



}
