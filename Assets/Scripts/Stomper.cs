using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public int damageToDeal;

    private Rigidbody2D rBody;
    public float bounceForce;

    // Start is called before the first frame update
    void Start()
    {
        rBody = transform.parent.GetComponent<Rigidbody2D>(); //Get the component of the parent object
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
