using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject box;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //timer += Time.deltaTime;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) 
        {
            box.SetActive(false);
        }

        //timer += Time.deltaTime;
        //if (timer > 1)
        //{
        //    Time.timeScale = 1;
        //}
    }
}
