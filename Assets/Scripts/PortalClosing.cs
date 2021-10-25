using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalClosing : MonoBehaviour
{
    [SerializeField] private float x, y;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isClosing", true);
            StartCoroutine(PortalRespawn());
        }
    }

    IEnumerator PortalRespawn()
    {
        //Still need to fix the portal coming back
        yield return new WaitForSeconds(1.0f);
        this.transform.position = new Vector2(x, y);
    }
}
