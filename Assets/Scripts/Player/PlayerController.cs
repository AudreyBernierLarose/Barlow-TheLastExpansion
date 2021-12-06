using UnityEngine;
using UnityEngine.SceneManagement;

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
    private CapsuleCollider2D capsuleColliders2D;

    //Serialized fields
    [SerializeField] private float runSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private GameObject infoPanel;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        infoPanel.SetActive(false);
        capsuleColliders2D = transform.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isJumping", isJumping);
        Jump();
        CheckGlidingScene();
    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        isGrounded = GroundCheck();

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //Communicate with the animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isCrouching", isCrouching);
        anim.SetFloat("crouching", Input.GetAxis("Crouch"));

        //Character movements
        Flip();
        Run();
        Crouch();
        ShowInfo();
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius * 2f, whatIsGround);
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow))
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
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
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
            NotGliding();

        if (Input.GetKeyDown(KeyCode.F) && !isGrounded && (rBody.velocity.y < 0 || rBody.velocity.y > 0))
            if (StardustPoints.dustValue <= 0)
                NotGliding();
            
            else 
            {
                anim.SetBool("isFloating", true);
                rBody.angularDrag = 2f;
                rBody.gravityScale = 0.3f;
                rBody.velocity = new Vector2(rBody.velocity.x, -2f);
                StardustPoints.dustValue -= 2;
            }
        
    }

    private void CheckGlidingScene()
    {
        if (SceneManager.GetActiveScene().name == "The Portal Escapade")
            NotGliding();
        
        else
            Gliding();
    }

    public void NotGliding()
    {
        anim.SetBool("isFloating", false);
        rBody.gravityScale = 3f;
        rBody.angularDrag = 0.05f;
    }

    private void ShowInfo()
    {
        if (Input.GetButton("Mouse X"))
            infoPanel.SetActive(true);
    
        else
            infoPanel.SetActive(false);
        
    }
}
