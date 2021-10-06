using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalClosing : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            anim.SetBool("isClosing", true);
    }
}
