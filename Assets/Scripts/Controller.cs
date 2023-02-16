using System.Runtime.ExceptionServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DynamicJoystick joystick;

    
    [SerializeField] float speedY = 6f;
    [SerializeField] float speedZ = 6f;
    [SerializeField] private float speedCh = 3f;

    [SerializeField] [Range(0,1)] Transform movementFactor;
    
    public Transform point; // The point to which the object should be kept within a certain distance
    public float maxDistance = 5f; // The maximum distance the object can be from the point
    public GameObject JoystickBackground;
    
    public Fuel fuel;
    public UIManager uı;
    public Rigidbody character;
    public Animator animator;

    

    Vector3 firstpos;
    
    
    void Start()
    {
      firstpos = new Vector3(character.transform.position.x,character.transform.position.y,character.transform.position.z);
      
    }

    
    

    void FixedUpdate()
    {
        PositionHandler();
        animationHandler();
        MovePlayer(speedY,speedZ);
        MovementStopping();
    }
    public void MovePlayer(float speedy,float speedz)
    {
        if (fuel.currentFuel > 0)
        {
            if(Input.touchCount > 0 || Input.GetMouseButton(0))
            {      
               
                _rigidbody.velocity =
                    new Vector3(_rigidbody.velocity.x, (joystick.Vertical*speedY), joystick.Horizontal * speedz * (-1));
                characterMover();
                var zValue = Input.GetAxis("Horizontal") * Time.deltaTime * speedy;
                var yValue = Input.GetAxis("Vertical") * Time.deltaTime * speedz;
                transform.Translate(zValue, 0, yValue);
                fuel.fuelDown();
            }  
            
        }
        else
        {
            uı.GameOver();
            fuel.currentFuel = PlayerPrefs.GetFloat("Fuel");

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

    void animationHandler()
    {
        if (character.velocity.y != 0)
        {
            animator.enabled = true;
        }
        else
        {
            animator.enabled = false;
        }
    }

    void characterMover()
    {
        if(joystick.Vertical > 0)
        {
            if(firstpos.y - character.transform.position.y >= -5f)
                {
                    character.velocity =
                    new Vector3(character.velocity.x, joystick.Vertical * speedCh, character.velocity.z);
                    
                }
                else
                {
                    character.velocity =
                    new Vector3(character.velocity.x, 0, character.velocity.z);
                    
                }
        }
        else if(joystick.Vertical < 0)
        {
             if(firstpos.y - character.transform.position.y <= 5f)
                {
                    character.velocity =
                    new Vector3(character.velocity.x, joystick.Vertical * speedCh, character.velocity.z);
                    
                }
                else
                {
                    character.velocity =
                    new Vector3(character.velocity.x, 0, character.velocity.z);
                    
                }
        }
        
        
    }


    void MovementStopping()
    {
        if(JoystickBackground.activeSelf == false)
        {
            character.velocity =
            new Vector3(character.velocity.x, 0, character.velocity.z);
        }
    }


   
    
    
}

