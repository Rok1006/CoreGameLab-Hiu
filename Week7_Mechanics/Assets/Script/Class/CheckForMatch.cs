using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForMatch : MonoBehaviour
{
    int x_count;
    int o_count;

    public void CheckMatches(bool XorO)
    {
       //Debug.Log("YOu win");
        if (XorO)
        {
            x_count++;
            Debug.Log(x_count);
            if (x_count == 3)
            {
                Debug.Log("YOu win");
            }
        }
        else
        {
            o_count++;
            Debug.Log(o_count);
            if (o_count == 3)
            {
                Debug.Log("another win");
            }
        }
    }
   




}
