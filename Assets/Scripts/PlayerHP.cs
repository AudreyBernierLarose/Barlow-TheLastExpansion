using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private Rigidbody2D rBody;
    private bool invisible = false;
    private SpriteRenderer spriteRenderer;
    private float invisibleDuration = 2.0f;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Score.scoreValue >= 1)
            {
                SetInvinsibility();
                rBody.velocity = Vector2.down * 1f; //This is for the flies
                Score.scoreValue--;
            }
            else
            {
                //Trigger Death animation here
                rBody.velocity = Vector2.down * 1f;
                Score.scoreValue--;
            }
        }

        if (other.gameObject.tag == "Lava")
        {
            SetInvinsibility();
            Score.scoreValue--;
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
