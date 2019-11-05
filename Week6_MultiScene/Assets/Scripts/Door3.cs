using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour
{
    public GameObject DoorThree;
    Animator Door3Anim;
    bool door3Open;
    public GameObject Door3Portal;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Door3Anim = DoorThree.GetComponent<Animator>();
        door3Open = true;
        Player.transform.eulerAngles = new Vector3(0, 180, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (door3Open)
        {
            Door3Anim.SetBool("Close", false);
            Door3Anim.SetBool("Open", true);
            Door3Portal.SetActive(true);
        }
    }
}
