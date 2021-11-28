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
    private float impactSize = 3;

    public LayerMask layerToHit;



    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.right);
        rb.velocity = new Vector3(5 * transform.right[0], 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_speed()
    {
        Debug.Log(transform.right);
        rb.velocity = new Vector3(direction.normalized[0], direction.normalized[1], 0)*speed;
    }
    void FixedUpdate()
    {
        time += 1;
        
        if(time == 70)
        {
            print("åååååååååååååååååå");
        }
        if(time >= 130)
        {
            Explode();
            print("ÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖ");
            Destroy(gameObject);
        }
        
    }
    
    void Explode()
    {
        print("dsddsdsadasdasda");
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactSize, layerToHit);

        foreach(Collider2D obj in objects)
        {
            //print(obj.gameObject.health);
            //print(PlayerMovement.health);
        	PlayerMovement e = obj.transform.GetComponent<PlayerMovement>();
            print(e);
            e.dmg();
            print(obj);
            print("dsdsddsdf");
        }
        
        
    }
    
}
