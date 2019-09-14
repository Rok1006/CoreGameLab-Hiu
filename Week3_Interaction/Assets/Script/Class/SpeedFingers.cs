using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedFingers : MonoBehaviour
{
    float timer;
    bool GtoH;
    public Text Num;

    // Start is called before the first frame update
    void Start()
    {
        GtoH = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        if (GtoH)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Num.text = timer.ToString();
                timer = 0;
                GtoH = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Num.text = timer.ToString();
                timer = 0;
                GtoH = true;
            }

        }
            timer += Time.deltaTime;

        }
        }



