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
        if (other.gameObject.tag == "Bounce" && rBody.velocity.y <= 0)
        {
            rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
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
    }

}
