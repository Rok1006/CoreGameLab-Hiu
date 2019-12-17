using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightPlatReset : MonoBehaviour
{
    public GameObject weightPlat;
    Animator WPanim;
    public GameObject Bk1;
    public GameObject Bk2;
    // Start is called before the first frame update
    void Start()
    {
        WPanim = weightPlat.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            DetectWeight.Instance.weightAdd = 0;
            DetectWeight.Instance.playerOn = false;
            Debug.Log("Down");
            //DetectWeight.Instance.WAanim.SetBool("MoveDown",true);
           //WPanim.SetBool("MoveUp", false);
            //WPanim.SetTrigger("Stay");
            //destroy block, block back to original position
            Bk1.transform.position = new Vector2(34f, 1.39f);
            Bk2.transform.position = new Vector2(35f, 1.39f);
          
        }
    }
}
