using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider seeableLevel;
    public GameObject Reveal;   //the seethrough area
    public GameObject RevealforAnim;
    public GameObject player;
    public GameObject revealPos;
    public Button glass;
    public GameObject glassButton;
    int sizeX;
    int sizeY;
    int sizeZ;
    public float timer;
    public bool started;
    public bool whenToStart;
    public Canvas Instruct;
    Animator seeAnim;
    public bool playAnim;
    public float startTime;   //for counting when to start showing the circle of see through


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        startTime = 0;
        seeableLevel.maxValue = 11;
        seeableLevel.value = 0;
        sizeX = 0;
        sizeY = 0;
        sizeZ = 0;
        Reveal.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
        started = false;
        glassButton.SetActive(false);
        Instruct.GetComponent<Canvas>().enabled = true;
        seeAnim = RevealforAnim.GetComponent<Animator>();
        playAnim = false;
        Reveal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instruct.GetComponent<Canvas>().enabled = false;
        }




        Reveal.transform.position = revealPos.transform.position;
        RevealforAnim.transform.position = revealPos.transform.position;

        if (started)
        {
            timer += Time.deltaTime;
        }
        if (timer > 3)
        {
            Reveal.transform.localScale -= new Vector3(1, 1, sizeZ);
            seeableLevel.value--;
            timer = 0;
        }
        if(seeableLevel.value == 10)
        {
            glass.interactable = false;
            glassButton.SetActive(false);  //use only once, die three times to replay the game
        }
        if (seeableLevel.value == 0)
        {
            Reveal.transform.localScale = new Vector3(0, 0, sizeZ);
        }

        if(Player.Instance.gotIt == true)
        {
            Debug.Log("Got it");
            glassButton.SetActive(true);   //player to press
        }
        if (playAnim)
        {
            seeAnim.SetBool("Glimpse", true);
            playAnim = false;
        }
        /////the animation of revealt
        if (whenToStart)
        {
            startTime += Time.deltaTime;
        }
        if (startTime > 1)
        {
            Reveal.SetActive(true);
        }


    }

    public void ClickGlass()
    {
        seeableLevel.value=10;   //original 0
        Reveal.transform.localScale = new Vector3(10, 10, sizeZ);   //start with the size of 10, original 1,1
        started = true;
        playAnim = true;
        whenToStart = true;

    }
}
