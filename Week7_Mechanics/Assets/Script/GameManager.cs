using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider seeableLevel;
    public GameObject Reveal;
    public GameObject player;
    public GameObject revealPos;
    public Button glass;
    public GameObject glassButton;
    int sizeX;
    int sizeY;
    int sizeZ;
    public float timer;
    public bool started;
    public Canvas Instruct;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        seeableLevel.maxValue = 10;
        seeableLevel.value = 0;
        sizeX = 0;
        sizeY = 0;
        sizeZ = 0;
        Reveal.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
        started = false;
        glassButton.SetActive(false);
        Instruct.GetComponent<Canvas>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instruct.GetComponent<Canvas>().enabled = false;
        }




        Reveal.transform.position = revealPos.transform.position;

        if (started)
        {
            timer += Time.deltaTime;
        }
        if (timer > 2.5)
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
        else
        {
            //glass.interactable = true;
        }

        if(Player.Instance.gotIt == true)
        {
            glassButton.SetActive(true);
        }
    }

    public void ClickGlass()
    {
        seeableLevel.value++;
        Reveal.transform.localScale += new Vector3(1, 1, sizeZ);
        started = true;
    }
}
