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
   // public Canvas Lose;
    public int dead;
    public GameObject GasJar;
    Animator[] GasAnim;
    //int gascount;
    public static HitDead Instance;
   void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //Lose.GetComponent<Canvas>().enabled = false;
        dead = 0;
        //GasAnim[0] = HealthManager.Instance.GasInstanciated[0].GetComponent<Animator>();   //doesnt workkkkk
        //GasAnim[1] = HealthManager.Instance.GasInstanciated[1].GetComponent<Animator>();
        //GasAnim[2] = HealthManager.Instance.GasInstanciated[2].GetComponent<Animator>();
        //gascount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if(dead == 3)
        //{
        //    Lose.GetComponent<Canvas>().enabled = true;
        //}
        //if(Lose.GetComponent<Canvas>().enabled == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        SceneManager.LoadScene(1);  //reload scene
        //    }
        //    if (Input.GetKeyDown(KeyCode.M))
        //    {
        //        SceneManager.LoadScene(0);  //reload scene
        //    }
        //}
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.transform.position = respawnPT.transform.position;
            BBK.transform.position = BBKRespawn.transform.position;
            PBK.transform.position = PBKRespawn.transform.position;
            HealthManager.Instance.death++;
            HealthManager.Instance.gasleak = true;
            //Debug.Log(dead + " " + gascount);
            //GasAnim.SetBool("Decreased", true);


            //for (int i = HealthManager.Instance.slot.Length - 1; i >= 0; i--)
            //{
            if (HealthManager.Instance.full[HealthManager.Instance.gascount] == true)
                    {
                        //Debug.Log("yo");
                    //if(HealthManager.Instance.full[0] == true)
                    //{
                    //    //GasAnim[0].SetBool("Decreased", true);
                    //    //trying to play the animation
                    //    //HealthManager.Instance.GasInstanciated[gascount].GetComponent<Animator>().SetTrigger("healthdown");
                    //}
                    //if (HealthManager.Instance.full[1] == true)
                    //{
                    //    //GasAnim[1].SetBool("Decreased", true);
                    //    //GasAnim[1].SetTrigger("healthdown");
                    //}
                    //if (HealthManager.Instance.full[2] == true)
                    //{
                    //    //GasAnim[2].SetBool("Decreased", true);
                    //   //GasAnim[2].SetTrigger("healthdown");
                    //}
                        HealthManager.Instance.GasInstanciated[HealthManager.Instance.gascount].GetComponent<Animator>().SetTrigger("healthdown");
                        HealthManager.Instance.full[HealthManager.Instance.gascount] = false;

                HealthManager.Instance.gascount--;
                    //Destroy(HealthManager.Instance.slot[i]);
                        //break;
                    }

                //}
            



        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = respawnPT.transform.position;
            BBK.transform.position = BBKRespawn.transform.position;
            PBK.transform.position = PBKRespawn.transform.position;
            HealthManager.Instance.death++;
            HealthManager.Instance.gasleak = true;
            //for (int i = HealthManager.Instance.slot.Length - 1; i >= 0; i--)
            //{
            //    if (HealthManager.Instance.full[i] == true)
            //    {
            //        Debug.Log("yo");
            //        //Destroy(HealthManager.Instance.slot[i]);
            //        HealthManager.Instance.full[i] = false;
            //        break;
            //    }

            //}
            if (HealthManager.Instance.full[HealthManager.Instance.gascount] == true)
            {
          
                HealthManager.Instance.GasInstanciated[HealthManager.Instance.gascount].GetComponent<Animator>().SetTrigger("healthdown");
                HealthManager.Instance.full[HealthManager.Instance.gascount] = false;

                HealthManager.Instance.gascount--;
                //Destroy(HealthManager.Instance.slot[i]);
                //break;
            }

        }
    }
}
