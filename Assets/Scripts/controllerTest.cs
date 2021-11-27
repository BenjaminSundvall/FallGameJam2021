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
        Debug.Log("MoveX: " + Input.GetAxis("MoveX"));
        Debug.Log("MoveY: " + Input.GetAxis("MoveY"));
        Debug.Log("AimX: " + Input.GetAxis("AimX"));
        Debug.Log("AimY: " + Input.GetAxis("AimY"));

    }
}
