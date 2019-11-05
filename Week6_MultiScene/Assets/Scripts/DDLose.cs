using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDLose : MonoBehaviour
{
    public static DDLose L;
    // Start is called before the first frame update
    void Awake()
    {
        if (L == null)
        {
            L = this;
            DontDestroyOnLoad(this);
        }
        else if (L != this)
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
