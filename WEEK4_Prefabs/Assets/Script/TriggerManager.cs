using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameObject Treasure;
    public GameObject Target1;
    public GameObject Target2;
    Animator animator;
    public float speed;
    public bool trigger;
    public GameObject spawnPoint;
    public GameObject bug_P;
    public float timer;
    public int kill;
    public static TriggerManager Instance;
    public AudioSource first;
    public AudioSource second;

    public bool startSpawn;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = Treasure.GetComponent<Animator>();
        Treasure = GameObject.FindGameObjectWithTag("T");
        AudioSource[] audios = GetComponents<AudioSource>();
        first = audios[0];
        second = audios[1];
       //trigger = false;

        first.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (kill > 5)
        {
            spawnPoint.SetActive(false);
            trigger = false;
        }



        //Treasure.transform.position = new Vector2(0f, 0f);
        if (trigger == true)
        {
           // first.Stop();
           //second.Play();
            float step = speed * Time.deltaTime;
            Treasure.transform.position = Vector3.MoveTowards(Treasure.transform.position, Target1.transform.position, step);
        }
        if(trigger == false)
        {
       
            float step = speed * Time.deltaTime;
            Treasure.transform.position = Vector3.MoveTowards(Treasure.transform.position, Target2.transform.position, step);
        }

        timer += Time.deltaTime;

        if (startSpawn)
        {
            if (timer > 4)
            {
                //Vector2 direction = (Vector2)((point.transform.position - transform.position));
                //direction.Normalize();
                Instantiate(bug_P, spawnPoint.transform.position, Quaternion.identity);
                //BugManager.Instance.health = 3;
                timer = 0;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("On");
            //Treasure.transform.position = new Vector2(13.79f, 9.62f) *speed;
            trigger = true;
            startSpawn = true;
            timer = 0;
      


            //trigger spawning of monster
        }
    }
}
