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
        Gliding();
    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //Communicate with the animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isCrouching", isCrouching);
        anim.SetFloat("crouching", Input.GetAxis("Crouch"));

        Debug.Log("Crouch Input get axis" + Input.GetAxis("Crouch"));

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
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D)) && isGrounded || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A)) && isGrounded || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow))
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
        if (Input.GetKey(KeyCode.C) && isGrounded)
        {
            anim.SetBool("isCrouching", !isCrouching);
            anim.SetFloat("crouching", -1f);
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

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                isJumping = true;
                rBody.velocity = Vector2.up * 10f;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    if (canDoubleJump)
                    {
                        isJumping = true;
                        rBody.velocity = Vector2.up * 10f;
                        canDoubleJump = false;
                    }
            }
        }
    }

    private void Gliding()
    {
        if (isGrounded)
        {
            anim.SetBool("isFloating", false);
            rBody.gravityScale = 3f;
            rBody.angularDrag = 0.05f;
        }

        if (Input.GetKeyDown(KeyCode.F) && !isGrounded && (rBody.velocity.y < 0 || rBody.velocity.y > 0))
        {
            anim.SetBool("isFloating", true);
            rBody.angularDrag = 2f;
            rBody.gravityScale = 0.3f;
            rBody.velocity = new Vector2(rBody.velocity.x, -2f);
        }
    }

    public void Sliding()
    {
        rBody.velocity = new Vector2(speed * 6f, rBody.velocity.y);
    }
}
