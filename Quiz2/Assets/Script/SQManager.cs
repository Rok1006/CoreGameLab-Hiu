using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SQManager : MonoBehaviour
{
    public GameObject sq;
    public float timer;
    public Text t;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        t.text = "Dont let the square catch you!";
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        float step = GameManager.GM.sqSpeed * Time.deltaTime;
        sq.transform.position = Vector3.MoveTowards(sq.transform.position, mousePos, step);

        //float steps = 2 * Time.deltaTime;   //test
        //sq.transform.position = Vector3.MoveTowards(sq.transform.position, mousePos, steps);

        //Vector3 direction = new Vector2(mousePos.x - sq.transform.position.x, mousePos.y - sq.transform.position.y);
       //Vector2 dist = new Vector2(sq.transform.position.x-mousePos.x, sq.transform.position.y - mousePos.y );
        float dist = Vector3.Distance(mousePos, sq.transform.position);
        if (dist<2.5 )
        {

            timer -= Time.deltaTime;
            t.text = timer.ToString();
        }
        if (timer < 0)
        {
            SceneManager.LoadScene(sceneName);
        }

        //if(sq.transform.position == mousePos)
        //{
        //    timer += Time.deltaTime;
        //}
    }
}
