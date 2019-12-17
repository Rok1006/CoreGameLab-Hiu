using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Header("SetOne")]
    public string[] setOne;
    int set1Index;
   
    [Header("SetTwo")]
    public string[] setTwo;
    int set2Index;

    [Header("Common")]
    public float speed;
    public GameObject Continue;
    Animator nextAnim;
    public int loadSet;
    public GameObject DialogueBox;
    Animator DiaAnim;
    public Text DialogueText;
    public static Dialogue Instance;

   void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        loadSet = 1;

        set1Index = 0;
        set2Index = 0;
        DialogueText.text = "";
        StartCoroutine(TextTyper());
        Continue.SetActive(false);
        nextAnim = Continue.GetComponent<Animator>();
        DiaAnim = DialogueBox.GetComponent<Animator>();
        //DialogueText.text = sentences[index];
    }

    // Update is called once per frame
    void Update()
    {
        //if set1Index == ?number(last sentence),if click, diabox disappear, load set = 2

        if (loadSet == 1)
        {

            if (DialogueText.text == setOne[set1Index])
            {
               //Debug.Log("Doing");
                Continue.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ContinueClick();
                }
            }
            else
            {
                Continue.SetActive(false);
            }
        }

        if(loadSet == 2)
        {
            if (DialogueText.text == setTwo[set2Index])
            {
                //Debug.Log("Doing");
                Continue.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ContinueClick();
                }
            }
            else
            {
                Continue.SetActive(false);
            }
        }





    }
    public void ContinueClick()
    {
        nextAnim.SetTrigger("Press");
        if (loadSet == 1)
        {
            set1Index++;
            if (set1Index > setOne.Length - 1)
            {
                //set1Index = 0;
                DiaAnim.SetBool("Disappear", true);
                DiaAnim.SetBool("Appear", false);
                //loadSet = 2;
            }
            DialogueText.text = "";
            StartCoroutine(TextTyper());
        }

        if (loadSet == 2)
        {
            set2Index++;
            if (set2Index > setTwo.Length - 1)
            {
                //set1Index = 0;
                DiaAnim.SetBool("Disappear", true);
                DiaAnim.SetBool("Appear", false);
                //DO STH, COUNT DOWN TIME
                //MachineManager.Instance.AlarmUp = true;
                //MachineManager.Instance.ShowTime = true;

            }
            if(set2Index == 1)//after great job
            {
                //MachineManager.Instance.AlarmUp = true;
                //MachineManager.Instance.ShowTime = true;
            }
            DialogueText.text = "";
            StartCoroutine(TextTyper());
        }
    }

    IEnumerator TextTyper()
    {
        if (loadSet == 1)
        {
            foreach (char c in setOne[set1Index].ToCharArray())
            {
                DialogueText.text += c;
                yield return new WaitForSeconds(speed);

            }    //allow checking each character in a sentences
        }

        if (loadSet == 2)
        {
            foreach (char c in setTwo[set2Index].ToCharArray())
            {
                DialogueText.text += c;
                yield return new WaitForSeconds(speed);

            }    //allow checking each character in a sentences
        }
    }
}
