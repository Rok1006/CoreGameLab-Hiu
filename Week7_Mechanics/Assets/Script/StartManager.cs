using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    public GameObject Title;
    public GameObject startbutton;
    public GameObject glass;
    public GameObject clickme;
    public Canvas TitleScreen;
    Animator titleAnim;
    Animator startAnim;
    Animator glassanim;

    // Start is called before the first frame update
    void Start()
    {
        titleAnim = Title.GetComponent<Animator>();
        startAnim = startbutton.GetComponent<Animator>();
        glassanim = glass.GetComponent<Animator>();
        TitleScreen.GetComponent<Canvas>().enabled = false;
        clickme.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickGlass()
    {
        TitleScreen.GetComponent<Canvas>().enabled = true;
        glassanim.SetBool("Move", true);
        titleAnim.SetBool("Appear", true);
        startAnim.SetBool("Appear", true);
        clickme.SetActive(false);
    }
    public void Startgame()
    {
        SceneManager.LoadScene(1);
    }
}
