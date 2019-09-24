using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 4;
   
    public GameObject spawnPoint;
    public TriggerManager t;
    public GameObject deadBug;
    public AudioSource first;
    public AudioSource second;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnP");
        t = GameObject.FindGameObjectWithTag
("Trigger").GetComponent<TriggerManager>();
        AudioSource[] audios = GetComponents<AudioSource>();
        first = audios[0];
        second = audios[1];

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            first.Play();
            Instantiate(deadBug, transform.position, Quaternion.identity);
            TriggerManager.Instance.kill++;
            //particles
        }
     

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health-=1;
        }
    }
}
