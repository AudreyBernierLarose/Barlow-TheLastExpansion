using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private Transform firePoint;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(spawn, firePoint.position, firePoint.rotation);
    }
}
