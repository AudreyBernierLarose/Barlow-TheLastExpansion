using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private float x, y;
    [SerializeField] private float setTimer;
    [SerializeField] private float bugTimer;

    private float timer = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > setTimer)
        {
            timer = 0;
            Destroy(Instantiate(spawn, new Vector3(x, y, 0), Quaternion.identity), bugTimer);
        }
    }
}
