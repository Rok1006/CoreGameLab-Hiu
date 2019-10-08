using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCannon : MonoBehaviour
{
    public Vector3 minPos;
    public Vector3 maxPos;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (Input.GetMouseButtonDown(0))
        //{
        //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //translate it into actual position
        //Debug.Log("Clicked" + worldPoint.x + " " + worldPoint.y);
        // }


         Vector3 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y); //getting the direction between one object to another
        transform.up = direction;
        //float angle = Mathf.Atan2(dirBtwSquare.y, dirBtwSquare.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);   //converting the angle of the objeect to another object
     Debug.Log(mousePos);

    }
}
