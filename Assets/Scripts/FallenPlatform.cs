using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenPlatform : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    [SerializeField] private float velocity;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isShaking", false) ;

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("In Collision Function");
            anim.SetBool("isShaking", true);
            StartCoroutine(WaitFallenPlatform());
        }
    }

    IEnumerator WaitFallenPlatform()
    {
        Debug.Log("In The WaitFallenPlatform Function");
        yield return new WaitForSeconds(3.0f);
        rBody.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        rBody.velocity = new Vector2(transform.position.x, velocity);

    }
}
