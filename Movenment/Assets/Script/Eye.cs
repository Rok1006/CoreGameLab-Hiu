using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dirBtwSquare = ball.transform.position - transform.position;
        float angle = Mathf.Atan2(dirBtwSquare.y, dirBtwSquare.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);   //converting the angle of the objeect to another object
        
    }
}

