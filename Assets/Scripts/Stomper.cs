using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    [SerializeField] private int damageToDeal;
    [SerializeField] private float bounceForce;

    private Rigidbody2D rBody;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        rBody = transform.parent.GetComponent<Rigidbody2D>(); //Get the component of the parent object
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hurtbox")
        {
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal); //this gets the enemy script
            rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
