using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 10f);

        timer += Time.deltaTime;
        if(timer > 0.5f)
        {
            Destroy(this.gameObject);
        }

    }
}
