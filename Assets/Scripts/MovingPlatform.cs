using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject platform2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            platform.SetActive(true);
            platform2.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        platform.SetActive(false);
    }
}
