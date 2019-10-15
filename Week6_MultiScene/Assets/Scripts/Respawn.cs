using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject ResPt;
    public GameObject Player;
    public int die;
    public Canvas Lose;
   public static Respawn Instance;
    AudioSource fail;

    void Awake()
    {
        Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        Lose.GetComponent<Canvas>().enabled = false;
        fail = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(die > 3)
        {
            Lose.GetComponent<Canvas>().enabled = true;
            //Time.timeScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = ResPt.transform.position;
            fail.Play();
            die++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = ResPt.transform.position;
            die++;
            fail.Play();
        }
    }
}
