using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleManager : MonoBehaviour
{
   // public bool XorO;
    public Color reddish;
    public Color bluish;
    public GameObject sprite;
    public Sprite x_sprite;
    public Sprite o_sprite;
    bool isX;

    public void SetTile(bool _XorO)
    {
        isX = _XorO;
        if (_XorO)
        {
            GetComponent<SpriteRenderer>().color = reddish;
            sprite.GetComponent<SpriteRenderer>().sprite = x_sprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = bluish;
            sprite.GetComponent<SpriteRenderer>().sprite = o_sprite;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //if (XorO)
        //{
        //    GetComponent<SpriteRenderer>().color = reddish;
        //    sprite.GetComponent<SpriteRenderer>().sprite = x_sprite;
        //}
        //else
        //{
        //    GetComponent<SpriteRenderer>().color = bluish;
        //    sprite.GetComponent<SpriteRenderer>().sprite = o_sprite;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
