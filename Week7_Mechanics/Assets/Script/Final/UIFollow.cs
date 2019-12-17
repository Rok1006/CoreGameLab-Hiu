using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollow : MonoBehaviour
{
    public Button Interact;
    //public Image DialogueBox;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 InteractPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Interact.transform.position = InteractPos;
        //DialogueBox.transform.position = InteractPos;
    }
}
