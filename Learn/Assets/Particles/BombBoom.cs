using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBoom : MonoBehaviour
{
    ParticleSystem p;
    SpriteRenderer s;

    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<ParticleSystem>();
        s = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void boom()
    {
        s.enabled = false;
      p.Play();
        Destroy(this.gameObject, p.duration);
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boom();
    }
}
