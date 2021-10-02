using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private fields
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private bool isCrouching = false;
    private Animator anim;

    //Serialized fields
    [SerializeField] private float runSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float jumpForce;
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
        
    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        //Jump code
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //Check if the sprite needs to be flipped
        if (rBody.velocity.x > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        
        else if (rBody.velocity.x < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);

        

        //Communicate with the animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isCrouching", isCrouching);

        Run();
        Crouch();
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    void Run()
    {
        //RUNNING MOVEMENT
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A)))
        {
            speed = runSpeed;
            anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        }

        else
        {
            speed = 4.0f;
            anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));   
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            anim.SetBool("isCrouching", !isCrouching);
            rBody.velocity = new Vector2(0.0f, 0.0f);
        }
        
    }
}
