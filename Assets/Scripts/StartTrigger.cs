using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject instructions;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            wall.SetActive(true);
            instructions.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        wall.SetActive(false);
        instructions.SetActive(true);
    }
}
