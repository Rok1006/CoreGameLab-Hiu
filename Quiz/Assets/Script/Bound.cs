using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    public GameObject ball_P;
    Vector2 randomPos;
    Rigidbody2D rb;
    //public Ball score;
    // public Color color;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
//        score = GameObject.Find
//("Ball").GetComponent<Ball>();
        //ball_P.color =  Color.black;    //ball = GameObject.FindWithTag("Ball");
        //transform.position = new Vector2(Random.Range(-17f, 17f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        //ball.transform.position = new Vector2(Random.Range(-17f, 17f), Random.Range(0f, 0f));
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       if(other.gameObject.tag ==("Ball")){
            //rb.velocity = Vector2.zero;
            ball_P.transform.position = new Vector2(Random.Range(-17f, 17f), Random.Range(12.5f, 12.5f));
            Vector3 randomPos = ball_P.transform.position;
            Instantiate(ball_P, randomPos, Quaternion.identity);

            Destroy(other.gameObject);
            GameManager.Instance.score=0;
            //transform.position = new Vector2(Random.Range(-17f, 17f), Random.Range(12.5f, 12.5f));

        }

    }
}
