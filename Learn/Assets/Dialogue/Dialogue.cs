using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] sentences;
    public Text DialogueText;

    int index;
    public float speed;
    public GameObject Continue;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        DialogueText.text = "";
        StartCoroutine(TextTyper());
        Continue.SetActive(false);
        //DialogueText.text = sentences[index];
    }

    // Update is called once per frame
    void Update()
    {
        //boring dialogue
        //    if (Input.GetKeyDown(KeyCode.Return))
        //    {
        //        index++;
        //        if(index > sentences.Length - 1)
        //        {
        //            index = 0;
        //        }
        //    }
        //    DialogueText.text = sentences[index];
        if(DialogueText.text == sentences[index])
        {
            Debug.Log("Doing");
            Continue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ContinueClick();
            //    index++;
            //    if (index > sentences.Length - 1)
            //    {
            //        index = 0;
            //    }
            //    DialogueText.text = " ";
            //    StartCoroutine(TextTyper());
            }
        }
        else
        {
            Continue.SetActive(false);
        }



    }
    public void ContinueClick()
    {
        index++;
            if (index > sentences.Length - 1)
            {
                index = 0;
            }
            DialogueText.text = "";
            StartCoroutine(TextTyper());
    }

    IEnumerator TextTyper()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            DialogueText.text += c;
            yield return new WaitForSeconds(speed);

        }    //allow checking each character in a sentences
    }
}
