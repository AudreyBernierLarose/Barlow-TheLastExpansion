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
        anim.SetBool("isStationary", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            anim.SetBool("isStationary", false);
            StartCoroutine(WaitSeconds());   
        }
    }

    IEnumerator WaitSeconds()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(10.0f);
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        anim.SetBool("isStationary", true);
    }
}
