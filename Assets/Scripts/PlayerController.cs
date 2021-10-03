using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private fields
    private Rigidbody2D rBody;
    private bool isGrounded;
    private bool isCrouching;
    private Animator anim;
    private bool isJumping;
    private float initialSpeed = 4.0f;
    private bool canDoubleJump;

    //Serialized fields
    [SerializeField] private float runSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isJumping", isJumping);
        Jump();

    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //Communicate with the animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isCrouching", isCrouching);

        

        //Character movements
        Flip();
        Run();
        Crouch();
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    private void Run()
    {
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D)) && isGrounded || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A)) && isGrounded)
        {
            speed = runSpeed;
            anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        }
        else
        {
            speed = initialSpeed;
            anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));   
        }
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) && isGrounded)
        {
            anim.SetBool("isCrouching", !isCrouching);
            rBody.velocity = new Vector2(0.0f, 0.0f);
        }
    }

    private void Flip()
    {
        //Check if the sprite needs to be flipped
        if (rBody.velocity.x > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

        else if (rBody.velocity.x < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void Jump()
    {
        isGrounded = GroundCheck();
        if (isGrounded)
        {
            isJumping = false;
            canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                isJumping = true;
                rBody.velocity = Vector2.up * 10f;
            }
            else 
            {
                if (canDoubleJump)
                {
                    isJumping = true;
                    rBody.velocity = Vector2.up * 10f;
                    canDoubleJump = false;
                }
            }
        }
    }
}
