using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
  
    AudioSource footstep;
    AudioSource glassPick;
    public bool gotIt;
    public GameObject Text1;
    public GameObject Text2;
    public Canvas Win;

    private void Awake()
    {
        Instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        AudioSource[] audios = GetComponents<AudioSource>();
        footstep = audios[0];
        glassPick = audios[1];
        gotIt = false;
        Text1.SetActive(false);
        Text2.SetActive(false);
        Win.GetComponent<Canvas>().enabled = false;
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

        if (Win.GetComponent<Canvas>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);  //reload scene

            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene(0);  //reload scene
            }
        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Glass")
        {
            glassPick.Play();
            gotIt = true;
            Destroy(col.gameObject);
            Text2.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "End")
        {
            Win.GetComponent<Canvas>().enabled = true;
        }
        if (col.gameObject.tag == "Text1")
        {
            Text1.SetActive(true);

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Text1")
        {
            Destroy(Text1);
        }
        if (col.gameObject.tag == "Text2")
        {
            Destroy(Text2);
        }
    }

}
