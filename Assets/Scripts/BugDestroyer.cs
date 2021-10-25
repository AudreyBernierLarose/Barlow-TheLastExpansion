using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hurtbox")
            Destroy(other.gameObject);
    }
}
