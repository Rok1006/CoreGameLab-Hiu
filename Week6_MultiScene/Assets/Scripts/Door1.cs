using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door1 : MonoBehaviour
{
    public Canvas Win;
    AudioSource win;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Win.GetComponent<Canvas>().enabled = false;
       win = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Win.GetComponent<Canvas>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
        }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Win.GetComponent<Canvas>().enabled = true;
            win.Play();
        }
    }
}
