using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{
    List<string> letters = new List<string>();
    string[] mywords = new string[]{"ONE", "TWO", "THREE", "FOUR"};
    string myword;
    public Text word;

    // Start is called before the first frame update
    void Start()
    {
        //myword = "SHOES";
        myword = mywords[Random.Range(0, mywords.Length - 1)];
        word.text = myword;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {

        if (Event.current.type == EventType.KeyDown && Event.current.keyCode != KeyCode.None)
        {
            Debug.Log("CurrentEvent:" + Event.current);
            letters.Add(Event.current.keyCode.ToString());

            for(int i = 0; i<= letters.Count -1; i++)
            {
                if (letters[i] == myword.Substring(i, 1))
                {
                    word.color = Color.green;

                    if (letters.Count == myword.Length)
                    {

                        //Debug.Log("yup " + letters[i] + " == " + myword.Substring(i, 1));
                        Debug.Log("yup " + myword + "Correct");
                        //word.fontStyle = FontStyle.Bold;
                        letters.Clear();
                        myword = mywords[Random.Range(0, mywords.Length - 1)];
                        word.text = myword;
                        word.color = Color.white;
                    }
                }
                else
                {
                    Debug.Log("boo you suck");
                    word.color = Color.red;
                    //Debug.Log("Nope " + letters[i] + " != " + myword.Substring(i, 1));
                    letters.Clear();
                }
            }
           //foreach (string letter in letters) { Debug.Log(letter); }
        }


    }
}
