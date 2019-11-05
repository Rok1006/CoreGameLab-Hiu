using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMoreB : MonoBehaviour
{

    public GameObject gridLayout;
    public GameObject Button;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newButton = Instantiate(Button, gridLayout.transform.position, Quaternion.identity);
            newButton.transform.parent = gridLayout.transform;

        }
    }
}
