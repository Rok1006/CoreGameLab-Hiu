using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoCollect : MonoBehaviour
{
    public int objectCount;
    public static CompoCollect Instance;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        objectCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "MachineCompo")
        {

            objectCount +=1;
            Destroy(col.gameObject);
            //Dialogue.Instance.loadSet = 2;
        }
    }

}
