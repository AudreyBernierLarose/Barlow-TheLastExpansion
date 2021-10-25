using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Text image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Text>();
        image.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HPScript.hpScore == 0)
        {
            image.enabled = true;
            StartCoroutine(WaitGO());   
        }
    }

    IEnumerator WaitGO()
    {
        yield return new WaitForSeconds(3.0f);
        image.enabled = false;
        SceneManager.LoadScene(0);
    }
}
