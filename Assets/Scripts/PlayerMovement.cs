using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController2D controller;
    //public Controller controller;

    public int health = 5;

    public float MovementSpeed = 3;
    public float JumpeForce = 10;
    public Rigidbody2D _rigidbody;
    private float movement;
    public AudioSource[] Sounds_In_GameFX;
    private int soundDelay = 0;
    public GameObject character;
    private List<string> animation_bools = new List<string>();
    //print("hej");

    public Animator anim;
    
    /*
    animation_bools.Add("is_running");
    animation_bools.Add("is_jumping");
    animation_bools.Add("is_throw");
    animation_bools.Add("is_dying");
    animation_bools.Add("is_hurt");
    */
   
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //_rigidbody.position = new Vector3(0f, 5f, 0);
        anim = GetComponent<Animator>();
        anim.SetBool("is_default", false);
        anim.SetBool("is_running", true);
        anim.SetBool("is_jumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        
        if(movement > 0.1 || movement < -0.1)
        {
            /*
            foreach (string animation_bools in animation_bools)
            {
                anim.SetBool(animation_bools, false);
            }
            */
            //print("oj");
            //print(anim.test);
            //anim.SetFloat("test", movement);
            anim.SetBool("is_default", false);
            anim.SetBool("is_running", true);
            if(soundDelay <= 0)
            {
                Sounds_In_GameFX[1].Play();
                soundDelay = 60;
            }else{
                soundDelay -=1;
            }
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
            if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                anim.SetBool("is_jumping", false);
            }
        }
        else
        {
            anim.SetBool("is_default", true);
            anim.SetBool("is_running", false);
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

    public void Jump(InputAction.CallbackContext context){
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f){
            anim.SetBool("is_jumping", true);
            _rigidbody.AddForce(new Vector2(0, JumpeForce), ForceMode2D.Impulse);
            Sounds_In_GameFX[0].Play();
        }
    }
    public void Move(InputAction.CallbackContext context) {
        movement = context.ReadValue<Vector2>().x;
        MabyRotate(movement);
    }

    public void dmg()
    {
        health -= 1;
        print(health);   
        if(health <= 0)
        {
            Destroy(character);
        }
    }

}
