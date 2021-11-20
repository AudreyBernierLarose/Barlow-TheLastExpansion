using System.Collections;
using UnityEngine;

public class FliesController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField]private Color newColor = Color.white;
    [SerializeField] private float setTimer;
    
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Renderer>().material.color = Color.white;
            this.transform.GetChild(i).GetComponent<Collider2D>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > setTimer)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).GetComponent<Renderer>().material.color = newColor;
                this.transform.GetChild(i).GetComponent<Collider2D>().enabled = true;
            }
            StartCoroutine(WaitSec());
        }
    }

    IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Renderer>().material.color = Color.white;
            this.transform.GetChild(i).GetComponent<Collider2D>().enabled = false;
        }
        timer = 0;
    }
}
