using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    private Rigidbody2D rBody;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.velocity = new Vector2(-speed, rBody.velocity.y);
    }
}
