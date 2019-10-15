using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAkeTiles : MonoBehaviour
{
    public GameObject tile_Prefab;
    Vector3 mouseWorldPos;
    Vector3 mouseScreenPos;
    bool XorO;

    bool dragging;
    GameObject currentTile;

    LayerMask gridLayer;
    LayerMask matchingLayer;

    // Start is called before the first frame update
    void Start()
    {
        gridLayer = LayerMask.GetMask("gridLayer");
        matchingLayer = LayerMask.GetMask("matchLayer");
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseScreenPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);

        if (dragging)
        {
            currentTile.transform.position = mouseScreenPos;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(mouseScreenPos, Vector2.zero,100f,gridLayer);
                if(hit.collider.gameObject.tag == "Grid")
                {
                    currentTile.transform.position = hit.collider.gameObject.transform.position;
                    dragging = false;
                    hit.collider.gameObject.SetActive(false);
                    checkForMatches(mouseScreenPos, XorO);
                    XorO = !XorO;
                }
            }
        }

    }
    void checkForMatches(Vector3 Pos, bool _XorO) 
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Pos, Vector2.zero, 100f, matchingLayer);
        if(hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; i++)
            {
                hits[i].collider.gameObject.GetComponent<CheckForMatch>().CheckMatches(_XorO);
            }
        }
    }

    public void Click()
    {
        if (!dragging)
        {
            currentTile = Instantiate(tile_Prefab, mouseScreenPos, Quaternion.identity);
            currentTile.GetComponent<TIleManager>().SetTile(XorO);
            dragging = true;
            //XorO = !XorO;
        }
    }
}
