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
    //private float angle = 30f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.right);
        rb.velocity = new Vector3(5 * transform.right[0], 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
