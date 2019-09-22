using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameObject Treasure;
    public GameObject Target1;
    Animator animator;
    public float speed;
    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        animator = Treasure.GetComponent<Animator>();
        Treasure = GameObject.FindGameObjectWithTag("T");
    }

    // Update is called once per frame
    void Update()
    {
        //Treasure.transform.position = new Vector2(0f, 0f);
        if (trigger == true)
        {
            float step = speed * Time.deltaTime;
            Treasure.transform.position = Vector3.MoveTowards(Treasure.transform.position, Target1.transform.position, step);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("On");
            //Treasure.transform.position = new Vector2(13.79f, 9.62f) *speed;
            trigger = true;
            //float step = speed * Time.deltaTime;
            //Treasure.transform.position = Vector3.MoveTowards(Treasure.transform.position, Target1.transform.position, step);
        
            //trigger spawning of monster
        }
    }
}
