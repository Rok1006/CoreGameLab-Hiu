using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float timer;
    public int bulletSpeed;
    Rigidbody2D rb;
    //public GameObject shotPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //PlayerMove.Instance.turnLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector2.right * bulletSpeed);

        if (PlayerMove.Instance.turnLeft == true)
        {
            rb.AddForce(Vector2.left * bulletSpeed);
        }
        if (PlayerMove.Instance.turnRight == true)
        {
            rb.AddForce(Vector2.right * bulletSpeed);
        }
        //transform.Translate(new Vector2(0.5f, 0) * bulletSpeed * Time.deltaTime);
        //transform.Translate(Vector2.up * Time.deltaTime * 10f);

        //float move = bulletSpeed * Time.deltaTime;
        //transform.Translate(shotPos.transform.position * move);

        //timer += Time.deltaTime;
        //if(timer > 0.5f)
        //{
        //    Destroy(this.gameObject);
        //}

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
