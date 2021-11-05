using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPoints : MonoBehaviour
{
    [SerializeField] private AudioClip starSound;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Star" && Input.GetKey(KeyCode.UpArrow))
        {
            AudioSource.PlayClipAtPoint(starSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 5f));
            StarScript.starPoints++;
            Score.scoreValue = Score.scoreValue + 5;
            Destroy(other.gameObject);
        }
    }
}
