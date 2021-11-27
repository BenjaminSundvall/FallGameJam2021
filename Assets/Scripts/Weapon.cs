using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Weapon : MonoBehaviour
{
    private Vector2 aim;
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }*/
    }
    public void Aim(InputAction.CallbackContext context){
        aim = context.ReadValue<Vector2>();
    }
    public void Shoot(InputAction.CallbackContext context)
    {   
        var bomb = Instantiate(bulletPrefab, firePoint.position+ new Vector3(aim.normalized[0], aim.normalized[1], 0), firePoint.rotation);
        bomb.GetComponent<Bomb>().direction = aim;
        bomb.GetComponent<Bomb>().Set_speed();
    }
}
