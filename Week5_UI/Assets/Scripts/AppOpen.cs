using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppOpen : MonoBehaviour
{

    public Canvas ChatRoom;
    public Canvas Error;
    public Canvas Note;
    AudioSource Click;
    public GameObject GameManager;

    public bool errorOpened;
    public bool noteOpened;
    public static AppOpen Instance;

    public Image Chat;
    Animator animChat;


    void Awake()
    {
        Instance = this;  
    }
    // Start is called before the first frame update
    void Start()
    {
        ChatRoom.GetComponent<Canvas>().enabled = false;
        Error.GetComponent<Canvas>().enabled = false;
        Note.GetComponent<Canvas>().enabled = false;
        Click = GameManager.GetComponent<AudioSource>();
        errorOpened = false;
        noteOpened = false;
        animChat = Chat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenChatRoom() {
        Click.Play();
        ChatRoom.GetComponent<Canvas>().enabled = true;
        animChat.SetBool("NoticeOn", false);
    }
    public void CloseChatRoom()
    {
        Click.Play();
        ChatRoom.GetComponent<Canvas>().enabled = false;
    }

    public void OpenSecretFolder() {
        Click.Play();
        Error.GetComponent<Canvas>().enabled = true;
        errorOpened = true;
        FlowManager.Instance.loadCount = 0;
    }


    public void CloseErrorWindow() {
        Click.Play();
        Error.GetComponent<Canvas>().enabled = false;
    }

    public void OpenNotePad()
    {
        Click.Play();
        Note.GetComponent<Canvas>().enabled = true;
        noteOpened = true;
    }
    public void CloseNotePad()
    {
        Click.Play();
        Note.GetComponent<Canvas>().enabled = false;
        noteOpened = false;
    }

}
