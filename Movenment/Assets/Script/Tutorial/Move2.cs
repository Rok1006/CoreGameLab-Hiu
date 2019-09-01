using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed;
    public GameObject othersquare;


    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale = (new Vector2(5, 0));
        speed = 0;


    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(Mathf.Sin(Time.time),1); //maniulating the scale
        transform.Rotate(0, 0, 1*speed);
        transform.Translate(new Vector2(1, 0) * Time.deltaTime);
        if(transform.position.x >= 19)
        {
            transform.position = new Vector2(-19, transform.position.y);
        }

        //
        //Vector2 dirBtwSquare = othersquare.transform.position - transform.position;
        //float angle = Mathf.Atan2(dirBtwSquare.y, dirBtwSquare.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);   //converting the angle of the objeect to another object
        //
    }
}
