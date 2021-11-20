using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 2f));
            Score.scoreValue += 1;
            Destroy(this.gameObject);
        }
    }
}
