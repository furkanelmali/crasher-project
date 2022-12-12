using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DynamicJoystick joystick;
    
    [SerializeField] float speed = 2f;
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
    }

    

    void MovePlayer()
    {
        _rigidbody.velocity =
            new Vector3(joystick.Vertical * speed , _rigidbody.velocity.y, joystick.Horizontal * speed* (-1));
        var xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var yValue = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(xValue, 0, yValue);
    }
}
