using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private float spawnX, spawnY;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Destroy(other.gameObject);
            StartCoroutine(WaitRespawn());
        }

        if (other.gameObject.tag == "LPlatform")
            Destroy(other.gameObject);
        
        if (other.gameObject.tag == "Asteroid")
            Destroy(other.gameObject);
    }

    IEnumerator WaitRespawn()
    {
        yield return new WaitForSeconds(10.0f);
        Instantiate(spawn, new Vector3(spawnX, spawnY, 0.0f), Quaternion.identity);
    }
}
