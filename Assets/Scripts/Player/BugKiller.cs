using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugKiller : MonoBehaviour
{
    private Rigidbody2D rBody;
    private SpriteRenderer spriteRenderer;
    private float invisibleDuration = 2.0f;
    private bool invisible = false;

    [SerializeField] private AudioClip killSound, hitSound;
    [SerializeField] private int damageToDeal;
    [SerializeField] private float bounceForce;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hurtbox" && rBody.velocity.y <= 0)
        {
            AudioSource.PlayClipAtPoint(killSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 1f));
            this.gameObject.GetComponentInParent<PlayerController>().NotGliding();
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal);
            rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Death") {
            HPScript.hpScore++;
        }

        if (other.gameObject.tag == "Spear") {
            this.gameObject.GetComponent<PlayerController>().NotGliding();
            SetInvinsibility();
            Score.scoreValue = Score.scoreValue - 3;
            HPScript.hpScore--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.gameObject.GetComponentInParent<Rigidbody2D>();
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
