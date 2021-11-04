using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPoints : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Star" && Input.GetKey(KeyCode.UpArrow))
        {
            StarScript.starPoints++;
            Score.scoreValue = Score.scoreValue + 5;
            Destroy(other.gameObject);
        }
    }
}
