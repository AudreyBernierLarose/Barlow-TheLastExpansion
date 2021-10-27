using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{

    [SerializeField] private GameObject spawn;
    [SerializeField] private float x, y;
    [SerializeField] private float time, repeatTime;

    private void Start()
    {
        Debug.Log("In the start Flame controller");
        InvokeRepeating("SpawningStars", time, repeatTime);
    }

    void SpawningStars()
    {
        Debug.Log("In the spawning stars Flame controller");
        Destroy(Instantiate(spawn, new Vector3(x, y, 0), Quaternion.identity), 2.0f);
    }

}
