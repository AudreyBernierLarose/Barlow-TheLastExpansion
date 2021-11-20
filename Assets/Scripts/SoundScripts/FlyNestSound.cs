using UnityEngine;

public class FlyNestSound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GetComponent<AudioSource>().Stop();
    }
}
