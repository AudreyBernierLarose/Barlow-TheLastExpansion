using System.Collections;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private Rigidbody2D rBody;
    private bool invisible = false;
    private SpriteRenderer spriteRenderer;
    private float invisibleDuration = 2.0f;
    private Animator anim;

    [SerializeField] private AudioClip hitSound, killSound;
    [SerializeField] private int damageToDeal;
    [SerializeField] private float bounceForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (HPScript.hpScore >= 1)
            {
                this.gameObject.GetComponent<PlayerController>().NotGliding();
                SetInvinsibility();
                rBody.velocity = Vector2.down * 1f; //This is for the flies
                Score.scoreValue = Score.scoreValue - 3;
                HPScript.hpScore--;
            }
            else
            {
                rBody.velocity = Vector2.down * 1f; //This is for the flies
                HPScript.hpScore -= HPScript.hpScore;
            }
        }

        if (other.gameObject.tag == "Death")
        {
            this.gameObject.GetComponent<PlayerController>().NotGliding();
            HPScript.hpScore -= HPScript.hpScore;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Asteroid")
        {
            this.gameObject.GetComponent<PlayerController>().NotGliding();
            SetInvinsibility();
            Score.scoreValue = Score.scoreValue - 3;
            HPScript.hpScore--;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.GetComponent<PlayerController>().NotGliding();
            SetInvinsibility();
            Score.scoreValue = Score.scoreValue - 3;
            HPScript.hpScore--;
        }
         
        if (other.gameObject.tag == "Lava")
        {
            if (HPScript.hpScore >= 1)
            {
                this.gameObject.GetComponent<PlayerController>().NotGliding();
                SetInvinsibility();
                Score.scoreValue = Score.scoreValue - 3;
                HPScript.hpScore--;
               
            }
            else
            {
                HPScript.hpScore -= HPScript.hpScore;
            }
        }

        if (other.gameObject.tag == "Spear")
        {
            this.gameObject.GetComponent<PlayerController>().NotGliding();
            SetInvinsibility();
            Score.scoreValue = Score.scoreValue - 3;
            HPScript.hpScore--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
        
    }

    public void SetInvinsibility()
    {
        AudioSource.PlayClipAtPoint(hitSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 1f));
        StopAllCoroutines();
        invisible = true;
        Invoke("UndoInvinsible", invisibleDuration);
        StartCoroutine(FlashSprite());
    }

    void UndoInvinsible()
    {
        invisible = false;
        StopAllCoroutines();
        spriteRenderer.enabled = true;
    }

    IEnumerator FlashSprite()
    {
        while (true)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(.4f);
        }
    }
}
