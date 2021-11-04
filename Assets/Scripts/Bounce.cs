using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    [SerializeField] private GameObject loading;
    [SerializeField] private float bounceForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bounce" && rBody.velocity.y < -1)
        {
            this.gameObject.GetComponent<PlayerController>().NotGliding();
            rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }

        else
            rBody.AddForce(transform.up * 1, ForceMode2D.Impulse);


        if (other.gameObject.tag == "End")
        {
            StartCoroutine(WaitTravel());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slide" && rBody.transform.rotation.y == 0)
        {
            anim.SetBool("isJumping", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        loading.SetActive(false);
        rBody = GetComponent<Rigidbody2D>();
    }

    IEnumerator WaitTravel()
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        HPScript.hpScore = 5;
        StarScript.starPoints = 0;
        Score.scoreValue = 0;
    }
}
