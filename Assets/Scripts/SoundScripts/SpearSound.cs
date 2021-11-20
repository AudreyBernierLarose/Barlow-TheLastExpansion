using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            this.gameObject.GetComponent<AudioSource>().Stop();
    }
}
