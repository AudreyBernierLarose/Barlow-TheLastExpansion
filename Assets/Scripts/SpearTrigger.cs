using UnityEngine;

public class SpearTrigger : MonoBehaviour
{
    [SerializeField] private GameObject spears;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            for (int i = 0; i < spears.transform.childCount; i++)
                spears.transform.GetChild(i).GetComponent<Animator>().SetBool("isUp", true);
    }
}
