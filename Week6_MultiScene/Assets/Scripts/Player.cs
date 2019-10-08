using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    public float speed;
    Vector2 movement;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    public Transform groundPos;  //feetpos
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    //private bool doubleJump;
    Animator animator;
    public static Player Instance;
    public bool gotBall;
    bool open;
    public bool goBack;
    AudioSource footstep;
    public GameObject words;
    public GameObject Trigger;

    private void Awake()
    {
        Instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gotBall = false;
        open = false;
        goBack = false;
        footstep = GetComponent<AudioSource>();
        words.SetActive(false);

    }

    void FixedUpdate() //!
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);  //wont lerp
    }
    public void AudioOne()
    {
        footstep.Play();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKey(jumpKey))  //jump
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == true)
        {
            animator.SetBool("isIDLE", true);
            animator.SetBool("isJumping", false);
            //animator.SetBool("isJumping", false);
            //Debug.Log("here");
        }
        else
        {
            animator.SetBool("isIDLE", false);
            animator.SetBool("isJumping", true);
        
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
                isJumping = false;
            }
        }
        // left and right movement
        movement = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            movement += Vector2.right;
            animator.SetBool("isWalking", true);
        }

        if (Input.GetKey(leftKey))
        {
            movement += Vector2.left;
            animator.SetBool("isWalking", true);
        }
   
        if (movement.x == 0)   //for animation just check the teacher sample
        {
            //animator.SetBool("isIDLE", true);
            animator.SetBool("isWalking", false);
        }
        else
        {
           animator.SetBool("isWalking", true);
            animator.SetBool("isIDLE", false);

        }

        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (gotBall)
        {
            open = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            gotBall = true;
            Destroy(col.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "GoBack")
        {
            goBack = true;
        }
        if (col.gameObject.tag == "Say")
        {
            words.SetActive(true);
        }
     }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Say")
        {
            words.SetActive(false);
            Destroy(Trigger);
        }
    }

}
