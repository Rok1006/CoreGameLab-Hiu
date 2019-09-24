using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Canvas start;


    // Start is called before the first frame update
    void Start()
    {
        start.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            start.GetComponent<Canvas>().enabled = false;
        }
    }
}
