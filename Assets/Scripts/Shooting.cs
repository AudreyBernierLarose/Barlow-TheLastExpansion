using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            if(SceneManager.GetActiveScene().name == "The Sanctuary")
                Shoot();
    }

    void Shoot()
    {
        Instantiate(spawn, firePoint.position, firePoint.rotation);
    }
}
