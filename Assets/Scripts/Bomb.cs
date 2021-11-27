using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject gameBullet; 
    public SpriteRenderer gameBulletRenderer;
    private int time = 0;
    public Vector2 direction;
    //private float angle = 30f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_speed(){
        Debug.Log(transform.right);
        rb.velocity = new Vector3(direction.normalized[0], direction.normalized[1], 0)*speed;
    }
    void FixedUpdate()
    {
        time += 1;
        Debug.Log(time);
        Debug.Log("fdf");
        
        if(time >= 130)
        {
            print("ÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖ");
            Destroy(gameObject);
        }
        
    }
}
