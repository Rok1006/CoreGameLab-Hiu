using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    Color[] colors = new Color[] { Color.red, Color.blue, Color.green };

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(AutoColorChange());
        StartCoroutine(ThreeColorChange());
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
    IEnumerator ThreeColorChange()
    {
        foreach(Color c in colors)  //for each spot in array, loop three times
        {
            GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator AutoColorChange()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(2);
        }
    }
}
