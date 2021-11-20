using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
            Destroy(other.gameObject);
    }
}
