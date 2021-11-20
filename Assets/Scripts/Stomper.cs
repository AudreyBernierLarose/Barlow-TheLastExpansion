using System.Collections;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    [SerializeField] private int damageToDeal;
    [SerializeField] private float bounceForce;

    private bool invisible = false;
    private SpriteRenderer spriteRenderer;
    private float invisibleDuration = 2.0f;
    private Rigidbody2D rBody;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        rBody = transform.parent.GetComponent<Rigidbody2D>(); //Get the component of the parent object
        col = GetComponent<Collider2D>();
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hurtbox")
        {
               other.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal); //gets the enemy script
               rBody.velocity = new Vector3(rBody.velocity.x, rBody.velocity.y * 0.0f + bounceForce, 0.0f);
        }
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
