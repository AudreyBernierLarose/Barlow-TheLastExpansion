using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    
    [SerializeField] private float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }
}
