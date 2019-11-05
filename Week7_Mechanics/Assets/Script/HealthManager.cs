using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public GameObject[] slot;
    public GameObject Gasjar; //prefab
    public bool[] full;
    public GameObject[] GasInstanciated;
    public static HealthManager Instance;
    public int gascount;
    public int death;
    public Canvas Lose;
    AudioSource gas;
    public bool gasleak;

    void Awake()
    {
        Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        gascount = 2;
        death = 0;
        for (int i = 0; i < slot.Length; i++)
        {
            //Debug.Log("yo");
            //if (full[i] == false)
            //{
                GameObject G = Instantiate(Gasjar, slot[i].transform, false);
                GasInstanciated[i] = G;
                full[i] = true;
                //break;
            //}
        }
        Lose.GetComponent<Canvas>().enabled = false;
        gas = GetComponent<AudioSource>();
        gasleak = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (death >= 3)
        {
            Lose.GetComponent<Canvas>().enabled = true;
        }
        if (Lose.GetComponent<Canvas>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);  //reload scene
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene(0);  //reload scene
            }
        }
        if (gasleak)
        {
            gas.Play();
            gasleak = false;
        }
    }
}
