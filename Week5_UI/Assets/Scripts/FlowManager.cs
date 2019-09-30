using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    public Image Assist;
    public Image Reminder;
    public Image Chat;
    Animator animAssist;
    Animator animReminder;
    Animator animChat;
    public int openReminderCount;
    public GameObject GameManager;

    public Text[] Do;
    Animator DoAnim1;
    Animator DoAnim2;
    Animator DoAnim3;
    Animator DoAnim4;
    Animator DoAnim5;
    public int loadCount;

    AudioSource notification;
    AudioSource noticeUp;
    AudioSource Click;
    public static FlowManager Instance;

    void Awake()
    {
        Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        animAssist = Assist.GetComponent<Animator>();
        animAssist.SetBool("NoticeOn", true);
        animReminder = Reminder.GetComponent<Animator>();
        animChat = Chat.GetComponent<Animator>();
        DoAnim1 = Do[0].GetComponent<Animator>();
        DoAnim2 = Do[1].GetComponent<Animator>();
        DoAnim3 = Do[2].GetComponent<Animator>();
        DoAnim4 = Do[3].GetComponent<Animator>();
        DoAnim5 = Do[4].GetComponent<Animator>();

        AudioSource[] audios = GetComponents<AudioSource>();
        notification = audios[0];
        noticeUp = audios[1];
        notification.Play();
        Click = GameManager.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (openReminderCount > 1)
        {
            //DoAnim2.SetBool("appear", true);
           //notification.Play();
        }
    }

    public void ReminderOpen()  //after notice, every first click
    {
        Click.Play();
        animReminder.SetBool("Up", true);
        animReminder.SetBool("Down", false);
        openReminderCount++;
        animAssist.SetBool("NoticeOn", false);
        DoAnim1.SetBool("appear", true);   //introduce

    }
    public void ReminderClose() 
    {
        Click.Play();
        animReminder.SetBool("Down", true);
        animReminder.SetBool("Up", false);
        animAssist.SetBool("NoticeOn", true);
    }
    public void LoadReminder()
    {

        noticeUp.Play();
        DoAnim2.SetBool("appear", true);
        loadCount++;
        if (AppOpen.Instance.errorOpened == true)
        {
            DoAnim3.SetBool("appear", true);
            if (loadCount >= 4)
            {
                DoAnim4.SetBool("appear", true);
                if (AppOpen.Instance.noteOpened == true)
                {
                    Debug.Log("yes");
                    DoAnim5.SetBool("appear", true);
             
                }
                if (loadCount >= 7)
                {
                    animChat.SetBool("NoticeOn", true);
                }
            }
        }
    

        //if sth happen, allow to appear 2
    }
}
