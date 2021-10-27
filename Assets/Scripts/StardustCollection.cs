using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StardustPoints.scoreValue ++;
            Destroy(this.gameObject);
        }
    }
}
