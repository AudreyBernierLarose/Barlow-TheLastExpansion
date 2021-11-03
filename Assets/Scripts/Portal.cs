using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject player;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isStationary", true);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            StartCoroutine(Teleportation());
    }

    IEnumerator Teleportation()
    {
        yield return new WaitForSeconds(1.0f);
        player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
    }
}
