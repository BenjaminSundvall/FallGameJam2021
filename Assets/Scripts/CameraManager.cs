using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    GameObject[] gameObjects;
    public Camera camera;

    private float aspectRatio = 16/9;
    [SerializeField]
    private float padding;
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
            Vector3 camCenterPoint = new Vector3(0, 0, -10);

            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = -float.MaxValue;
            float maxY = -float.MaxValue;

            foreach(GameObject gameobj in gameObjects){
                camCenterPoint += gameobj.transform.position;

                minX = Math.Min(minX, gameobj.transform.position.x);
                minY = Math.Min(minY, gameobj.transform.position.y);
                maxX = Math.Max(maxX, gameobj.transform.position.x);
                maxY = Math.Max(maxY, gameobj.transform.position.y);
            }

            transform.position = camCenterPoint/gameObjects.Length;
            
            float dx = maxX - minX;
            float dy = maxY - minY;

            if (dx < aspectRatio * dy){
                camera.orthographicSize = dy + padding;     // Hög
            } else {
                camera.orthographicSize = (1f / aspectRatio) * dx + padding; // Bred
            }
        }
    }

    public void Joined(PlayerInput input){
        gameObjects = GameObject.FindGameObjectsWithTag("Player");
    }
}
