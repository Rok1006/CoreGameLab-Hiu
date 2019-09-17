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
    public Image Error;
    public GameObject Player;
    public float timer;
    public static PlayerInput Instance;
     Rigidbody2D Rb; //player rigidbody
    float forceAmount;

    public bool moveRight;
    public bool moveLeft;
    public bool stop;
    public bool moveRightFaster;
    public bool moveLeftFaster;
    public bool boost;
    public bool jump;

    Animator animator;
    Spine.Bone myBone;

    public Transform groundPos;  //feetpos
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public float jumpForce;

    public Canvas startInstruct;



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
        Error.GetComponent<Image>().enabled = false;
        startInstruct.GetComponent<Canvas>().enabled = true;




        //command = inputField.GetComponent<Text>().text;
    }
    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
            command = mainInputField.text;
        if(mainInputField.text == "")
        {
            Error.GetComponent<Image>().enabled = false;
        }
        if (command == "++")
            {
                moveRight = true;
                moveLeft = false;
            moveRightFaster = false;
            moveLeftFaster = false;
            stop = false;
            boost = false;
            jump = false;
            Error.GetComponent<Image>().enabled = false;
            //mainInputField.text = "";

        } 
        else { Error.GetComponent<Image>().enabled = true; }
        if (command == "00")
            {
                moveRight = false;
                moveLeft = false;
            moveRightFaster = false;
            moveLeftFaster = false;
            stop = true;
            boost = false;
            jump = false;
            Error.GetComponent<Image>().enabled = false;
            //mainInputField.text = "";
        }
            if (command == "--")
            {
                moveRight = false;
                moveLeft = true;
            moveRightFaster = false;
            moveLeftFaster = false;
            stop = false;
            boost = false;
            jump = false;
            Error.GetComponent<Image>().enabled = false;
            //mainInputField.text = "";
        }
            if (command == "]]")
            {
                moveRightFaster = true;
                moveLeftFaster = false;
            moveRight = false;
            moveLeft = false;
            stop = false;
            boost = false;
            jump = false;
            Error.GetComponent<Image>().enabled = false;
            //mainInputField.text = "";
        }
            if (command == "[[")
            {
                moveRightFaster = false;
                moveLeftFaster = true;
            moveRight = false;
            moveLeft = false;
            stop = false;
            boost = false;
            jump = false;
            Error.GetComponent<Image>().enabled = false;
            //mainInputField.text = "";
        }
        if (command == "+]]")
        {
            moveRightFaster = false;
            moveLeftFaster = false;
            moveRight = false;
            moveLeft = false;
            boost = true;
            stop = false;
            jump = false;
            Error.GetComponent<Image>().enabled = false;
            //mainInputField.text = "";
        }
        if (command == "\\")
        {
            moveRightFaster = false;
            moveLeftFaster = false;
            moveRight = false;
            moveLeft = false;
            boost = false;
            stop = false;
            jump = true;
            Error.GetComponent<Image>().enabled = false;
            //mainInputField.text = "";
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startInstruct.GetComponent<Canvas>().enabled = false;
        }

        //____________________________________________________________________________________________________//
        if (moveRight == true)
        {
            animator.SetBool("isWalking", true);
           //animator.SetBool("isJump", false);
            //Player.transform.eulerAngles = new Vector3(0, 0, 0);
            //Player.transform.Translate(new Vector2(Player.transform.position.x + 1, 0) * speed * 0.01f);
            Rb.AddForce(new Vector2(3.5f, 1.0f) * 1.0f);
        }
        if (moveRightFaster == true)
        {
            animator.SetBool("isWalking", true);
            //animator.SetBool("isJump", false);
            Rb.AddForce(new Vector2(4.5f, 1.0f) * 1.0f);
            //Player.transform.eulerAngles = new Vector3(0, 180, 0);
            //Player.transform.Translate(new Vector2(Player.transform.position.x + 1, 0) * speed * 0.02f);  //try using rigidbody then
        }
        if (boost == true)
        {
            animator.SetBool("isWalking", true);
            //animator.SetBool("isJump", false);
            Rb.AddForce(new Vector2(8.0f, 1.0f) * 1.0f);
        }
        if (stop == true)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isJump", false);
            Rb.velocity = Vector2.zero;
            //Player.transform.Translate(0,0,0);
        }
        if (moveLeft == true)
        {
            animator.SetBool("isWalking", true);
            //animator.SetBool("isJump", false);
            Rb.AddForce(new Vector2(-3.5f, 1.0f) * 1.0f);
            //Player.transform.eulerAngles = new Vector3(0, 180, 0);
            //Player.transform.Translate(new Vector2(Player.transform.position.x + 1, 0) * -speed * 0.01f);
        }
        if (moveLeftFaster == true)
        {
            animator.SetBool("isWalking", true);
            //animator.SetBool("isJump", false);
            Rb.AddForce(new Vector2(-4.0f, 1.0f) * 1.0f);
        }
      
            //Rb.velocity = Vector2.up * 3;
            isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

            if (isGrounded == true && jump == true)  //jump
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                Rb.velocity = Vector2.up * jumpForce;
            }

            if (isGrounded == true)
            {
            //animator.SetBool("isWalking", false); //idle
            animator.SetBool("isJump", false); 
        }
            else
            {
            animator.SetBool("isJump", true);
        }

            if (jump == true && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    Rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }

                if (jump == false)
                {
                    isJumping = false;
                }
            }


        


    }

   
}
