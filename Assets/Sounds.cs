using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioSource[] soundFX;

    void Update()
    {
        if (Input.GetButtonDown("Jump1"))
        {
            soundFX[0].Play();
        }
        if (Input.GetButtonDown("Jump2"))
        {
            soundFX[1].Play();
        }
    }
}