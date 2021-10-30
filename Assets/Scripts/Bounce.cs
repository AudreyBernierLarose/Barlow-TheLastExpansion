using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rBody;

    [SerializeField] private float bounceForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bounce" && rBody.velocity.y < -1)
        {
            Debug.Log("Velocity Y" + rBody.velocity.y);
            rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
        else
        {
            rBody.AddForce(transform.up * 1, ForceMode2D.Impulse);
        }

        if (other.gameObject.tag == "End")
        {
            StartCoroutine(WaitTravel());  
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    IEnumerator WaitTravel()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        HPScript.hpScore = 5;
        StarScript.starPoints = 0;
        Score.scoreValue = 0;
    }

}
