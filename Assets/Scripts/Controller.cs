using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DynamicJoystick joystick;

    public Fuel fuel;
    
    [SerializeField] float speedY = 6f;
    [SerializeField] float speedZ = 6f;
    public Transform point; // The point to which the object should be kept within a certain distance
    public float maxDistance = 5f; // The maximum distance the object can be from the point

    public UIManager uı;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        PositionHandler();
        MovePlayer(speedY,speedZ);
    }



    public void MovePlayer(float speedy,float speedz)
    {
        if (fuel.currentFuel > 0)
        {
            if(Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                _rigidbody.velocity =
                    new Vector3(_rigidbody.velocity.x, joystick.Vertical * speedy, joystick.Horizontal * speedz * (-1));
                var zValue = Input.GetAxis("Horizontal") * Time.deltaTime * speedy;
                var yValue = Input.GetAxis("Vertical") * Time.deltaTime * speedz;
                transform.Translate(zValue, 0, yValue);
                fuel.fuelDown();
            }  
        }
        else
        {
            uı.GameOver();
            fuel.currentFuel = fuel.startingFuel;
        }
    }

    void PositionHandler()
    {
        // Calculate the distance between the object and the point
        float distance = Vector3.Distance(transform.position, point.position);

        // If the distance is greater than the maximum distance, move the object back to the maximum distance
        if (distance > maxDistance)
        {
            // Calculate the direction from the object to the point
            Vector3 direction = (point.position - transform.position).normalized;

            // Set the position of the object to be at the maximum distance from the point in the calculated direction
            transform.position = point.position - direction * maxDistance;
        }
    }
}

