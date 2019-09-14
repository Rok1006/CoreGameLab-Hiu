using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    //List<string> eachCom = new List<string>();
    public string command;
    public float speed;
    //public GameObject inputField;
    public InputField mainInputField;
    public GameObject Player;
    public float timer;
    public static PlayerInput Instance;
     Rigidbody2D Rb; //player rigidbody
    float forceAmount;

    public bool moveRight;
    public bool moveLeft;
    public bool stop;
    bool moveRightFaster;
    bool moveLeftFaster;
    bool boost; 


    Animator animator;
    Spine.Bone myBone;



    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        timer = 0;
        animator = Player.GetComponent<Animator>();
       Rb = Player.GetComponent<Rigidbody2D>();



        //command = inputField.GetComponent<Text>().text;
    }
    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
            command = mainInputField.text;
            if (command == "++")
            {
                moveRight = true;
                moveLeft = false;
            moveRightFaster = false;
            moveLeftFaster = false;
            stop = false;
            boost = false;
        }
            if (command == "00")
            {
                moveRight = false;
                moveLeft = false;
            moveRightFaster = false;
            moveLeftFaster = false;
            stop = true;
            boost = false;
        }
            if (command == "--")
            {
                moveRight = false;
                moveLeft = true;
            moveRightFaster = false;
            moveLeftFaster = false;
            stop = false;
            boost = false;
        }
            if (command == "\\")
            {
                moveRightFaster = true;
                moveLeftFaster = false;
            moveRight = false;
            moveLeft = false;
            stop = false;
            boost = false;
        }
            if (command == "//")
            {
                moveRightFaster = false;
                moveLeftFaster = true;
            moveRight = false;
            moveLeft = false;
            stop = false;
            boost = false;
        }
        if (command == "+\\")
        {
            moveRightFaster = false;
            moveLeftFaster = false;
            moveRight = false;
            moveLeft = false;
            boost = true;
            stop = false;
        }


    }
    // Update is called once per frame
    void Update()
    {

        //____________________________________________________________________________________________________//
        if (moveRight == true)
        {
            animator.SetBool("isWalking", true);
            //Player.transform.eulerAngles = new Vector3(0, 0, 0);
            //Player.transform.Translate(new Vector2(Player.transform.position.x + 1, 0) * speed * 0.01f);
            Rb.AddForce(new Vector2(3.5f, 1.0f) * 1.0f);
        }
        if (moveRightFaster == true)
        {
            animator.SetBool("isWalking", true);
            Rb.AddForce(new Vector2(4.5f, 1.0f) * 1.0f);
            //Player.transform.eulerAngles = new Vector3(0, 180, 0);
            //Player.transform.Translate(new Vector2(Player.transform.position.x + 1, 0) * speed * 0.02f);  //try using rigidbody then
        }
        if (boost == true)
        {
            animator.SetBool("isWalking", true);
            Rb.AddForce(new Vector2(8.0f, 1.0f) * 1.0f);
        }
        if (stop == true)
        {
            animator.SetBool("isWalking", false);
            Rb.velocity = Vector2.zero;
            //Player.transform.Translate(0,0,0);
        }
        if (moveLeft == true)
        {
            animator.SetBool("isWalking", true);
            Rb.AddForce(new Vector2(-3.5f, 1.0f) * 1.0f);
            //Player.transform.eulerAngles = new Vector3(0, 180, 0);
            //Player.transform.Translate(new Vector2(Player.transform.position.x + 1, 0) * -speed * 0.01f);
        }
        if (moveLeftFaster == true)
        {
            animator.SetBool("isWalking", true);
            Rb.AddForce(new Vector2(-4.0f, 1.0f) * 1.0f);
        }


    }

    public void SubmitCommand() //if type in sthsth that is right do sthsth
    {
        //command = inputField.GetComponent<Text>().text;
        //command = mainInputField.text;

        //if (command == "d++")
        //{
        //    moveRight = true;
        //}
        //if (command == "stop")
        //{
        //    moveRight = false;
        //    stop = true;
        //}
    }
}
