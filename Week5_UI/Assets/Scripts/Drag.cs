using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // public Canvas CodeBox;
    // private Vector2 pos;
    //private bool pickedUp = false;

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        //CodeBox = GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
