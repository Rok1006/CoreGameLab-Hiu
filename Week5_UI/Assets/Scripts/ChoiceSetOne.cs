using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSetOne : MonoBehaviour
{
    public Text TextBox;
    public Text OP1;
    public Text OP2;
    public Text PLayerBox;
    public int choiceMade;
    public string[] villGdText;
    public string[] villBdText;
    public string[] answer1;
    public string[] answer2;
    int count1;
    int count2;
    int connect;
    Animator anim;
    public string[] previousAnswer;
    public Text online;
    AudioSource TextSend;
    public int press;

    public void Option1()
    {
        //TextBox.GetComponent<Text>().text = villText[0];
        //online.GetComponent<Text>().enabled = true;
        count1++;
        count2++;
        connect++;
        DisplayAnswer1();
        DisplayAnswer2();
        DisplayNextGdQuestion();
        TextSend.Play();
        press++;
     }
    public void Option2()
    {
        //TextBox.GetComponent<Text>().text = villText[1];
        //online.GetComponent<Text>().enabled = true;
        count2++;
        count1++;
        connect++;
        DisplayAnswer1();
        DisplayAnswer2();
        DisplayNextBdQuestion();
        TextSend.Play();
        //previousAnswer = answer2;
        press++;

    }


    // Start is called before the first frame update
    void Start()
    {
        online.text = "OFFLINE";
       //online.GetComponent<Text>().enabled = true;
        TextBox.GetComponent<Text>().text = villGdText[0];
        count1 = 0;
        count2 = 0;
      
        anim = TextBox.GetComponent<Animator>();
        anim.SetBool("Up", false);
        DisplayAnswer1();
        DisplayAnswer2();

        AudioSource[] audios = GetComponents<AudioSource>();
        TextSend = audios[1];
        //previousAnswer[0] = answer1[count1];
    }

    // Update is called once per frame
    void Update()
    {
        //previousAnswer[0] = answer1[count1];
        for (int i = 0; i< previousAnswer.Length; i++) 
        {
            //PLayerBox.GetComponent<Text>().text = previousAnswer[i];
        }
        //if(OP1.text == answer1[3])
        //{
        //    online.GetComponent<Text>().enabled = true;
        //}
        if(press == 10)
        {
            online.text = "OFFLINE";
        }

        if (connect == 2)
        {
            online.text = "ONLINE";
        }

    }

    void DisplayAnswer1()
    {
        OP1.text = answer1[count1*1];
        //previousAnswer[0] = answer1[count1 * 1];
        //PLayerBox.GetComponent<Text>().text = answer1[count1-1];
        //do not fill in the zero space
    }
    void DisplayAnswer2()
    {
        OP2.text = answer2[count2 * 1];
          //do not fill in the zero space
    }

    void DisplayNextGdQuestion() 
    {
        //anim.SetBool("Up", true);
        TextBox.GetComponent<Text>().text = villGdText[count1 * 1];

    }
    void DisplayNextBdQuestion()
    {
        //anim.SetBool("Up", true);
        TextBox.GetComponent<Text>().text = villBdText[count2 * 1];
     
    }
 

}
