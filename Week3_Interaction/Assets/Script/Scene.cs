using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scene : MonoBehaviour
{
    public GameObject CodeBox;
    public GameObject Notepad;
    public GameObject CodeB;
    public GameObject NoteB;
    public Canvas hint;
    public bool playnote;
    public bool playcode;

    Animator codeAnim;
    Animator noteAnim;
    public Canvas Lose;

    public int death;
    public static Scene Instance;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        death = 0;
        codeAnim = CodeB.GetComponent<Animator>();
        noteAnim = NoteB.GetComponent<Animator>();
        CodeBox.SetActive(false);
        Notepad.SetActive(false);
        hint.GetComponent<Canvas>().enabled = true;
        playcode = false;
        playnote = false;
        Lose.GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (playcode)
        {
            codeAnim.SetBool("Pressed",true);
        }
        else
        {
            codeAnim.SetBool("Pressed", false);
        }
        if (playnote)
        {
            noteAnim.SetBool("Pressed", true);
        }
        else
        {
            noteAnim.SetBool("Pressed", false);
        }

        if (death >= 5)
        {
            Lose.GetComponent<Canvas>().enabled = true;
        }
        if (Lose.GetComponent<Canvas>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerInput.Instance.stop = true;
                Lose.GetComponent<Canvas>().enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    public void CodeBoxOpen()
    {
        //codeAnim.SetTrigger("Pressed");
        playcode = true;
        CodeBox.SetActive(true);
        hint.GetComponent<Canvas>().enabled = false;
    }
    public void CodeBoxExit()
    {
        playcode = false;
        CodeBox.SetActive(false);
    }
    public void NoteOpen()
    {
        playnote = true;
        Notepad.SetActive(true);
        hint.GetComponent<Canvas>().enabled = false;
    }
    public void NoteExit()
    {
        playnote = false;
        Notepad.SetActive(false);
    }



}
