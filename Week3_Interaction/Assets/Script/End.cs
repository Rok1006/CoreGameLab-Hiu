using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Canvas EndInstruct;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        EndInstruct.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(EndInstruct.GetComponent<Canvas>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.RightCommand))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
      
    }
void OnTriggerEnter2D(Collider2D col)
    {
        EndInstruct.GetComponent<Canvas>().enabled = true;

    }
}
