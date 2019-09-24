using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public bool detected;
    Animator animator;
    Vector2 pos;
    public GameObject poisonP;
    Rigidbody2D rb;
    public int attackSpeed;
    public float timer;
    public GameObject point;

    public bool left;
    public bool right;

   //public static BugManager Instance;
    public int health;

    public float stoppingDistance;
    public float RetreatDistance;
    public AudioSource first;
    public AudioSource second;
    //public GameObject deadBug;

    //void Awake()
    //{
    //    Instance = this;
    //}
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //poisonP = GameObject.FindGameObjectWithTag("Poison");
        animator = GetComponent<Animator>();
        rb = poisonP.GetComponent<Rigidbody2D>();
        //health = 3;
        AudioSource[] audios = GetComponents<AudioSource>();
        first = audios[0];
        second = audios[1];

    }


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > stoppingDistance)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
        else if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance && Vector2.Distance(transform.position, player.transform.position) > RetreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.transform.position) < RetreatDistance)
        {
            float step = -speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

        //Dead
        //if (health <= 0)
        //{
        //    Destroy(gameObject);
        //    //health = 3;
        //    //particles
        //}







        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        pos = player.transform.position;
        if (pos.x < 0)  //to the right
        {
            //Debug.Log("Yup");
            left = true;
            right = false;
            //transform.eulerAngles = new Vector3(0, 180, 0); //how to flip
        }
        if (pos.x > 0)
        {
            right = true;
            left = false;
            //Debug.Log("Nope");
            //transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (left == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (right == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        timer += Time.deltaTime;

        if (detected)
        {
            animator.SetBool("isAngry", true);
            if (timer > 1)
            {
                //Vector2 direction = (Vector2)((point.transform.position - transform.position));
                //direction.Normalize();
                Instantiate(poisonP, point.transform.position, Quaternion.identity);
                second.Play();
                timer = 0;
            }
            //converting the angle of the objeect to another object


            // poisonP.transform.position += transform.forward * Time.deltaTime * attackSpeed;
        }
        else
        {
            animator.SetBool("isAngry", false);
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("YEs..");
            detected = true;

        }


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detected = false;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Instantiate(deadBug, transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
    }
}