using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HPScript.hpScore == 0)
        {
            image.enabled = true;
            StartCoroutine(WaitLoading());   
        }
    }

    IEnumerator WaitLoading()
    {
        yield return new WaitForSeconds(2.0f);
        image.enabled = false;
        SceneManager.LoadScene(0);
    }
}
