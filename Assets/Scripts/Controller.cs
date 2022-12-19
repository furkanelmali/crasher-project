using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DynamicJoystick joystick;

    
    [SerializeField] private float YLimiter, ZLimiter, MZLimiter = 7f; 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PositionHandler();
        MovePlayer(5f,5f);
    }



    void MovePlayer(float speedy,float speedz)
    {
        _rigidbody.velocity =
            new Vector3(_rigidbody.velocity.x, joystick.Vertical * speedy, joystick.Horizontal * speedz * (-1));
        var zValue = Input.GetAxis("Horizontal") * Time.deltaTime * speedy;
        var yValue = Input.GetAxis("Vertical") * Time.deltaTime * speedz;
        

        transform.Translate(zValue, 0, yValue);
    }

    void PositionHandler()
    {
       
        

    } 
}

