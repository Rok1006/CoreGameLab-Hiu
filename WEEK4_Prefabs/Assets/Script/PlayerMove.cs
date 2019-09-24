using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Header("Player")]
    public float jumpForce;
    private Rigidbody2D rb;
    public float speed;
    Vector2 movement;

    [Header("Input")]
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    [Header("GroundD")]
    public Transform groundPos;  //feetpos
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public bool isMoving;
    Animator animator;

    [Header("Bullet")]
    public GameObject bulletP;
    public GameObject shotPos;
    public float bulletSpeed;
    private Rigidbody2D Rb;
    public bool turnRight;
    public bool turnLeft;

    public static PlayerMove Instance;
    public string sceneName;
    AudioSource audio;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Rb = bulletP.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate() //!
    {
        //Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);  //wont lerp
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
            GameObject bullet = (GameObject)Instantiate(
                                    bulletP,
                                    shotPos.transform.position,
                                    Quaternion.identity);
          
            // Adds velocity to the bullet

            //bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(5f,0f) * Time.deltaTime * bulletSpeed;
        }
    










        ////////////////
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKey(jumpKey))  //jump
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == true)
        {
           animator.SetBool("isIdle", true);
            animator.SetBool("isJump", false);
            //animator.SetBool("isJump", false);  //idle
            //Debug.Log("here");
        }
        else
        {
            animator.SetBool("isJump", true);  //jump
            animator.SetBool("isIdle", false);
        }

        if (Input.GetKey(jumpKey) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

            if (Input.GetKeyUp(jumpKey))
            {
                animator.SetBool("isJump", true);
                animator.SetBool("isIdle", false);
                isJumping = false;

            }
        }
        // left and right movement
        movement = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            movement += Vector2.right;
            turnRight = true;
            turnLeft = false;
        }

        if (Input.GetKey(leftKey))
        {
            movement += Vector2.left;
            turnLeft = true;
            turnRight = false;
        }
        //if (Input.GetKey(jumpKey))
        //{
        //    animator.SetBool("isJump", true);
        //}
        //else
        //{
        //    animator.SetBool("isJump", false);
        //}

        if (movement.x == 0)   //for animation just check the teacher sample
        {
            isMoving = false;
            //animator.SetBool("isIdle", true);
            //animator.SetBool("isJump", false);
            animator.SetBool("isWalk", false);
        }
        else
        {
            animator.SetBool("isIdle", false);
            //animator.SetBool("isJump", false);
            animator.SetBool("isWalk", true);
            //animator.SetBool("isJump", false);

        }

        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isMoving = true;
}
        else if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            isMoving = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Treasure")
        {
            //SceneManager.LoadScene(sceneName);
        }
    }
}

