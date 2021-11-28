using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps; 
public class DestructableTiles : MonoBehaviour {
    public Tilemap destructableTilemap;
    public GameObject cactus; 
    private void Start() {
        destructableTilemap = GetComponent<Tilemap>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
     
        if(collision.gameObject.CompareTag("Penile") || collision.gameObject.CompareTag("Bullet")) {
           
            Vector3 hitposition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts){
                hitposition.x = hit.point.x; //- 0.01f * hit.normal.x;
                hitposition.y = hit.point.y; //- 0.01f * hit.normal.y;
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitposition), null);
                Debug.Log(collision);
                Debug.Log(hit);
            }
        }
    }
private void OnCollisionStay2D(Collision2D collision) {
     
        if(collision.gameObject.CompareTag("Penile") || collision.gameObject.CompareTag("Bullet")) {
           
            Vector3 hitposition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts){
                hitposition.x = hit.point.x; //- 0.01f * hit.normal.x;
                hitposition.y = hit.point.y; //- 0.01f * hit.normal.y;
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitposition), null);
                Debug.Log(collision);
                Debug.Log(hit);
            }
        }
}
        private void OnCollisionExit2D(Collision2D collision) {
     
        if(collision.gameObject.CompareTag("Penile") || collision.gameObject.CompareTag("Bullet")) {
           
            Vector3 hitposition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts){
                hitposition.x = hit.point.x; //- 0.01f * hit.normal.x;
                hitposition.y = hit.point.y; //- 0.01f * hit.normal.y;
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitposition), null);
                Debug.Log(collision);
                Debug.Log(hit);
            }
        }
        }

    void OnTriggerEnter2D()
    {
      
    }
    }
    
