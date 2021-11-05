using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSoundTrigger : MonoBehaviour
{
    [SerializeField] private GameObject lava;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            lava.gameObject.GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            lava.gameObject.GetComponent<AudioSource>().Stop();
    }


}
