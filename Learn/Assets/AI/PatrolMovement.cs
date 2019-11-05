using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public GameObject[] patrolSpot;
    int whichPoint;
   public static bool isChasing;
    float dist;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0;
        isChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * 3);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolSpot[whichPoint].transform.position, Time.deltaTime*3);
            dist = Vector2.Distance(transform.position, patrolSpot[whichPoint].transform.position);
            if(dist<= 0.01f)
            {
                whichPoint += 1;
                if(whichPoint>= 4)
                {
                    whichPoint = 0;
                }
            }
        }



        for (int i = 0; i < patrolSpot.Length; i++)
        {

        }
    }
}
