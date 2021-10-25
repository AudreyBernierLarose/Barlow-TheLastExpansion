using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPoints : MonoBehaviour
{
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Star" && Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("In the Star trigger function");
            StarScript.starPoints++;
            Destroy(other.gameObject);
        }
    }
}
