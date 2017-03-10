using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity;

    public AudioSource jumpSoundEffect;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
   // private bool doubleJump;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        
            //doubleJump = false;
            anim.SetBool("Grounded", grounded);
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded && Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (jumpHeight));
            HighJump();
            GetComponent<AudioSource>().Play();
        }

        //used for a double jump
        //if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJump)
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        //    Jump();
        //    doubleJump = true;
        //    GetComponent<AudioSource>().Play();
        //}

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = moveSpeed;

        }

        //Holding down left shift increases run speed
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            moveVelocity = -moveSpeed -2;
        }
        //Holding down left shift increases run speed
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            moveVelocity = moveSpeed + 2;

        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        //changing the way facing
       if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    //higher jump if left shift pressed
    public void HighJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight + 2f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}


