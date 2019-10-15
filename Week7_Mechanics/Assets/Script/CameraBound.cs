using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBound : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject Player;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    public static CameraBound Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
