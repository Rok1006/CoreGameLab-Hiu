using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject plat_prefab;
    Vector3 mousePos;
    float timer;
    public float interval;

    // Start is called before the first frame update
    void Start()
    {
       //Instantiate(plat_prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>= interval)
        {
            //Vector3 pos = new Vector3(Random.Range(-10f, 10), 10f, 0f);
            //Instantiate(plat_prefab, pos, Quaternion.identity);
            //timer = 0;

            //GameObject p;
            //p = Instantiate(plat_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            //float width = Random.Range(3, 8);
            //p.transform.localScale = new Vector2(width, p.transform.localScale.y);
            ////p.GetComponent<PlatMove>().speed = Random.Range(1, 5);
            //timer = 0;
        }



        //if (Input.GetMouseButtonDown(0))
        //{
        //    mousePos = Input.mousePosition;
        //    mousePos.z = 0f;
        //    var worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        //    Instantiate(plat_prefab, worldPos, Quaternion.identity);
        //}

    }
    }
