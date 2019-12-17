using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
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
    Animator anim;
    public static PlayerMove Instance;

    AudioSource footstep;
    AudioSource glassPick;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        AudioSource[] audios = GetComponents<AudioSource>();
        footstep = audios[0];
        glassPick = audios[1];

    }

    void FixedUpdate() //!
    {
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);  //wont lerp
    }
    public void AudioOne()
    {
        if (isGrounded == true)
        {
            footstep.Play();
        }
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
        if (isGrounded == false && Input.GetKey(jumpKey))  //jump
        {
            isJumping = false;
        }

            if (isGrounded == true)   //useGUILayout boolean to switch mode
        {

           anim.SetBool("Idle", true);
            anim.SetBool("Jump", false);
           
        }
        else
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Jump", true);
        
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
            anim.SetBool("Walk", true);
            //anim.SetBool("Jump", false);
            //anim.SetBool("Idle", false);
        }

        if (Input.GetKey(leftKey))
        {
            movement += Vector2.left;
           anim.SetBool("Walk", true);
            //anim.SetBool("Jump", false);
             //anim.SetBool("Idle", false);
        }
   
        if (movement.x == 0)   //for animation just check the teacher sample
        {
           //anim.SetBool("Idle", true);
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Idle", false); 
            anim.SetBool("Walk", true);
            //animator.SetBool("isIDLE", false);

        }

        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MachineCompo")
        {
            glassPick.Play();
        }
        }

        void OnTriggerEnter2D(Collider2D col)
    {
     
     }
    void OnTriggerExit2D(Collider2D col)
    {
       
    }

}
