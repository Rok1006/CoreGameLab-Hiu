using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{

    public int Bspeed;
    public int Wspeed;
    float max_x;
    float min_x;
    public GameObject BkBirdPrefab;
    public GameObject WhBirdPrefab;
    public float Btimer;
    public float Wtimer;
    public GameObject spawnPtBk;
    public GameObject spawnPtWh;


    // Start is called before the first frame update
    void Start()
    {
        max_x = 19;
        min_x = -19;
        Btimer = 0;
        Wtimer = 0;
        //transform.position = new Vector2(0, 11);
    }

    // Update is called once per frame
    void Update()
    {
        Btimer += Time.deltaTime;
        Wtimer += Time.deltaTime;
        //transform.position = new Vector2(Random.Range(-18, 18), Random.Range(11, 11));
        //transform.position = new Vector2(Random.Range(-19.0f, 19.0f)* speed, Random.Range(-11, -11) *speed);
        spawnPtBk.transform.Translate(new Vector2(5f, 0) * Bspeed * Time.deltaTime);

        if(spawnPtBk.transform.position.x >= max_x)
        {
            spawnPtBk.transform.position = new Vector2(-max_x - 0.1f, spawnPtBk.transform.position.y);
        }
        //Instantiate(bkBirdPrefab, transform.position, Quaternion.identity);
        if (Btimer > 0.6)
        {
            Instantiate(BkBirdPrefab, spawnPtBk.transform.position, Quaternion.identity);
            Btimer = 0;
        }
        //
        spawnPtWh.transform.Translate(new Vector2(-5f, 0) * Wspeed * Time.deltaTime);

        if (spawnPtWh.transform.position.x <= min_x)
        {
            spawnPtWh.transform.position = new Vector2(-min_x - 0.1f, spawnPtWh.transform.position.y);
        }
        //Instantiate(bkBirdPrefab, transform.position, Quaternion.identity);
        if (Wtimer > 0.5)
        {
            Instantiate(WhBirdPrefab, spawnPtWh.transform.position, Quaternion.identity);
            Wtimer = 0;
        }
    }
}
