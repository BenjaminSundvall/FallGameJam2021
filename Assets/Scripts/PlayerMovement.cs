using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController2D controller;
    //public Controller controller;

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
    GameObject[] playerNumbers;
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
        anim = GetComponent<Animator>();
        playerNumbers = GameObject.FindGameObjectsWithTag("Player");
        for(int i =0; i < playerNumbers.Length; i++)
        {
            print(playerNumbers[i]);
            print("hej");
        }
        print("Öööööööö");

        //anim.SetBool("is_default", false);
        //anim.SetBool("is_running", true);
    }

    // Update is called once per frame
    void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        anim.SetBool("is_throwing", false);
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

            if (character = playerNumbers[0])
            {
                anim.SetBool("is_player", false);
            }
            else
            {
                anim.SetBool("is_player", true);
            }

            anim.SetBool("is_default", false);
            anim.SetBool("is_running", true);
            if (anim.GetBool("is_jumping") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                anim.SetBool("is_jumping", false);
            }
            else
            {
                anim.SetBool("is_jumping", true);
            }

            if (soundDelay <= 0)
            {
                Sounds_In_GameFX[1].Play();
                soundDelay = 60;
            }else{
                soundDelay -=1;
            }
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        }
        else
        {
            if (anim.GetBool("is_jumping") && Mathf.Abs(_rigidbody.velocity.y) > 0.001f)
            {
                anim.SetBool("is_jumping", false);
            }
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
            anim.SetBool("is_default", false);
            anim.SetBool("is_running", false);
            anim.SetBool("is_jumping", true);
            _rigidbody.AddForce(new Vector2(0, JumpeForce), ForceMode2D.Impulse);
            Sounds_In_GameFX[0].Play();
        }
    }
    public void Move(InputAction.CallbackContext context) {
        movement = context.ReadValue<Vector2>().x;
        MabyRotate(movement);
    }

}
