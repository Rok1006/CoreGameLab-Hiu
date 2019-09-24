using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerHealth : MonoBehaviour
{
    public int playerHP;
    public static PLayerHealth Instance;
    public Canvas end;
    public Canvas Win;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHP = 10;
        end.GetComponent<Canvas>().enabled = false;
        Win.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP == 0)
        {
            end.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            Win.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        }
}
