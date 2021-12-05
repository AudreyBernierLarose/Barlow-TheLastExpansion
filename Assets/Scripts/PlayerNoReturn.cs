using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoReturn : MonoBehaviour
{

 

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
