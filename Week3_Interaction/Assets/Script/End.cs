using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Canvas EndInstruct;
    // Start is called before the first frame update
    void Start()
    {
        EndInstruct.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightCommand))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
void OnTriggerEnter2D(Collider2D col)
    {
        EndInstruct.GetComponent<Canvas>().enabled = true;

    }
}
