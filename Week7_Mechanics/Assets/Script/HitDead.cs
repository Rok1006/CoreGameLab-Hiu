using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HitDead : MonoBehaviour
{
    public GameObject respawnPT;
    public GameObject Player;
    public GameObject BBKRespawn;
    public GameObject PBKRespawn;
    public GameObject BBK;
    public GameObject PBK;
    public Canvas Lose;
    public int dead;

    // Start is called before the first frame update
    void Start()
    {
        Lose.GetComponent<Canvas>().enabled = false;
        dead = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == 3)
        {
            Lose.GetComponent<Canvas>().enabled = true;
        }
        if(Lose.GetComponent<Canvas>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);  //reload scene

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.transform.position = respawnPT.transform.position;
            BBK.transform.position = BBKRespawn.transform.position;
            PBK.transform.position = PBKRespawn.transform.position;
            dead++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = respawnPT.transform.position;
            BBK.transform.position = BBKRespawn.transform.position;
            PBK.transform.position = PBKRespawn.transform.position;
            dead++;
        }
    }
}
