using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMovement : MonoBehaviour
{
    float x;
    float y;
    Vector2 pos;
    bool generatePos;
    float timer;
    bool startShoot;
    float shoot;
    public GameObject orange;
    public GameObject spawnPt;
    // Start is called before the first frame update
    void Start()
    {
        generatePos = true;
        StartCoroutine(Move());
        Instantiate(orange, spawnPt.transform.position, Quaternion.identity);
        timer = 0;
        startShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            //Instantiate(orange, spawnPt.transform.position, Quaternion.identity);
            StartCoroutine(Move());
            startShoot = true;
            //shoot += Time.deltaTime;

            timer = 0;
        }

        transform.position = pos;
        if (startShoot)
        {
            shoot += Time.deltaTime;
        }
        if (shoot > 1)
        {
            Instantiate(orange, spawnPt.transform.position, Quaternion.identity);
            shoot = 0;
            startShoot = false;
        }

    }
    IEnumerator Move()
    {
        x = Random.Range(-13f, 13f);
        y = Random.Range(2.7f, 2.7f);
        pos = new Vector2(x, y);
    
        yield return new WaitForSeconds(10);
    }
}
