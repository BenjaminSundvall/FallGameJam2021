using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource[] Sounds_In_GameFX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Sounds_In_GameFX[0].Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
