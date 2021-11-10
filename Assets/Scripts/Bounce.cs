using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    [SerializeField] private AudioClip congratClip;
    [SerializeField] private AudioClip bounceClip;
    [SerializeField] private GameObject loading;
    [SerializeField] private float bounceForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bounce" && rBody.velocity.y < -1)
        {
            AudioSource.PlayClipAtPoint(bounceClip, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 4f));
            this.gameObject.GetComponent<PlayerController>().NotGliding();
            rBody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }

        else
            rBody.AddForce(transform.up * 1, ForceMode2D.Impulse);


        if (other.gameObject.tag == "End")
            StartCoroutine(WaitTravel());
        

        if (other.gameObject.tag == "TheEnd")
            StartCoroutine(WaitCredit()); 
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
        AudioSource.PlayClipAtPoint(congratClip, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 4f));
        loading.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ResetInfo();
    }

    IEnumerator WaitCredit()
    {
        AudioSource.PlayClipAtPoint(congratClip, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 4f));
        loading.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        ResetInfo();
    }

    void ResetInfo()
    {
        HPScript.hpScore = 5;
        StarScript.starPoints = 0;
        Score.scoreValue = 0;
    }
}
