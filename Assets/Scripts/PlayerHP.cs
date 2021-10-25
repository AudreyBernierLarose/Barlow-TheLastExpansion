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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (HPScript.hpScore >= 1)
            {
                SetInvinsibility();
                rBody.velocity = Vector2.down * 1f; //This is for the flies
                Score.scoreValue--;
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
                SetInvinsibility();
                Score.scoreValue--;
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
            HPScript.hpScore -= HPScript.hpScore;
            Destroy(this.gameObject);
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
