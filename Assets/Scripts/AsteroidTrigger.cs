using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gObject;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
            gObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        gObject.SetActive(false);
    }
}
