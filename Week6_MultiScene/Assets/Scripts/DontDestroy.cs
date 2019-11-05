using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Vill;
    // Start is called before the first frame update
    void Awake()
    {
        if (Vill == null)
        {
            Vill = this;
            DontDestroyOnLoad(this);
        }
        else if (Vill != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
