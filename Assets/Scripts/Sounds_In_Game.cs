using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_In_Game : MonoBehaviour
{

    public AudioSource[] Sounds_In_GameFX;

    void Update()
    {
        if (Input.GetButtonDown("Jump1"))
        {
            Sounds_In_GameFX[0].Play();
        }
        if (Input.GetButtonDown("Jump2"))
        {
            Sounds_In_GameFX[1].Play();
        }
    }
}
