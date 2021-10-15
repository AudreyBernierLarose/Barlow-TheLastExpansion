using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rBody;

    [SerializeField] private float bounceForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bounce")
        {
            rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rBody = transform.parent.GetComponent<Rigidbody2D>();
    }
}
