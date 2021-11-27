using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("====================");
        Debug.Log("MoveX: " + Input.GetAxis("MoveX1"));
        Debug.Log("MoveY: " + Input.GetAxis("MoveY1"));
        Debug.Log("AimX: " + Input.GetAxis("AimX1"));
        Debug.Log("AimY: " + Input.GetAxis("AimY1"));
        Debug.Log("Fire: " + Input.GetButton("Fire1"));
        Debug.Log("Special: " + Input.GetButton("Special1"));
        Debug.Log("Jump: " + Input.GetButton("Jump1"));

    }
}
