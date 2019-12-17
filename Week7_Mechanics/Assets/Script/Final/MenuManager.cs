using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public string sceneName;
    public Canvas ControlInstruct;
    // Start is called before the first frame update
    void Start()
    {
        ControlInstruct.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Control(){
        ControlInstruct.GetComponent<Canvas>().enabled = true;
    }

    public void Back(){
        ControlInstruct.GetComponent<Canvas>().enabled = false;
    }




}
