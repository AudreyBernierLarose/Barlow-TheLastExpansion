using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    private Rigidbody2D rBody;
    private bool invisible = false;
    private SpriteRenderer spriteRenderer;
    private float invisibleDuration = 2.0f;

    [SerializeField] private int damageToDeal;
    [SerializeField] private float bounceForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
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
                //Trigger Death animation here
                rBody.velocity = Vector2.down * 1f; //This is for the flies
                HPScript.hpScore -= HPScript.hpScore;
            }               
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
                //Trigger Death animation here
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
        if (other.gameObject.tag == "Hurtbox")
        {
            if (rBody.velocity.y < 0)
            {
                this.gameObject.GetComponent<PlayerController>().NotGliding();
                other.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal); //this gets the enemy script
                rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
            }
            else
            {
                SetInvinsibility();
                Score.scoreValue = Score.scoreValue - 3;
                HPScript.hpScore--;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetInvinsibility()
    {
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
