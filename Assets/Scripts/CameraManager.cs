using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObjects.Length == 0){
            transform.position = new Vector3(0,0,-10);
        } else {
            Vector3 temp = new Vector3(0, 0, 0);
            foreach(GameObject gameobj in gameObjects){
                temp += gameobj.transform.position;
            }
            temp += new Vector3(0,0,-10 - temp.magnitude);
            transform.position = temp/gameObjects.Length;
        }
    }

    public void Joined(PlayerInput input){
        gameObjects = GameObject.FindGameObjectsWithTag("Player");
    }
}
