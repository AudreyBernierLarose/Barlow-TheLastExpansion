using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidingTutorial : MonoBehaviour
{
    [SerializeField] private GameObject instruction;

    //Setting active an object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            instruction.SetActive(true);

    }

    //Setting inactive an object
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            instruction.SetActive(false);

    }

    // Start is called before the first frame update
    private void Start()
    {
        instruction.SetActive(false);
    }
}
