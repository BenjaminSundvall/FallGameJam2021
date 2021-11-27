using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController2D controller;
    //public Controller controller;

    public float MovementSpeed = 3;
    public float JumpeForce = 10;
    private Rigidbody2D _rigidbody;
    public AudioSource[] Sounds_In_GameFX;
    private int soundDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        var movement = Input.GetAxis("MoveX1");
        MabyRotate(movement);
        
        if(movement > 0.1 || movement < -0.1)
        {
            if(soundDelay <= 0)
            {
                Sounds_In_GameFX[1].Play();
                soundDelay = 60;
            }else{
                soundDelay -=1;
            }
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        }
        
        if(Input.GetButtonDown("Jump1") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpeForce), ForceMode2D.Impulse);
            Sounds_In_GameFX[0].Play();
        }
        
    }

    //Kollar om man behöver rotera gubben
    void MabyRotate(float movement)
    {    
        if(movement > 0 && transform.localRotation[1] < 0)
        { 
            transform.Rotate(0f, 180f, 0);
            Debug.Log("Byt höger");
            //transform.localScale = new Vector3(1, 1.5f, 1);
            //transform.Rotate(0f, 180f, 0);
        }else if(movement < 0 && transform.localRotation[1] >= 0)
        {
            Debug.Log("Byt vänster");
            //transform.localScale = new Vector3(-1, 1.5f, 1);
            transform.Rotate(0f, -180f, 0);
        }

    }

}
