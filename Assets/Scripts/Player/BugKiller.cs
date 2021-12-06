using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugKiller : MonoBehaviour
{
    private Rigidbody2D rBody;
  
    [SerializeField] private AudioClip killSound;
    [SerializeField] private int damageToDeal;
    [SerializeField] private float bounceForce;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hurtbox" && rBody.velocity.y <= 0)
        {
            Debug.Log(rBody.velocity.y);
            AudioSource.PlayClipAtPoint(killSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 1f));
            this.gameObject.GetComponentInParent<PlayerController>().NotGliding();
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal);
            rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.gameObject.GetComponentInParent<Rigidbody2D>();
    }
}
