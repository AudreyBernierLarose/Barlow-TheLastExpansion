using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustCollection : MonoBehaviour
{
    [SerializeField] private AudioClip starCollectionSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(starCollectionSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 15f));
            StardustPoints.dustValue ++;
            Destroy(this.gameObject);
        }
    }
}
