using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene01 : MonoBehaviour
{
    public GameObject Player;
    public GameObject ball;
   public Canvas Instruct;
    public bool backInPos;
    public Canvas word;
    // Start is called before the first frame update
    void Start()
    {
        backInPos = false;
        //if (backInPos)
        //{
        //    Player.transform.position = new Vector2(85.2f, -4.13f);
        //    ball.transform.position = new Vector2(76.61f, -6.68f);
        //}
        Instruct.GetComponent<Canvas>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instruct.GetComponent<Canvas>().enabled = false;
            // Destroy(Instruct);

        }

        if (Ball.One.playerMove == true)
        {
            backInPos = true;
            Instruct.GetComponent<Canvas>().enabled = false;
            word.GetComponent<Canvas>().enabled = false;

        }

        if (backInPos)
        {
            Player.transform.position = new Vector2(85.2f, -4.13f);
            ball.transform.position = new Vector2(76.61f, -6.68f);
            backInPos = false;
            Ball.One.playerMove = false;
        }
    }
}
