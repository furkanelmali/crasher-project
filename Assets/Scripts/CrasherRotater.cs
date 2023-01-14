using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherRotater : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private Rigidbody rb;
    

    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        transform.rotation= Quaternion.Euler(rot.x,rot.y,rot.z+ rotationSpeed*Time.deltaTime);
        //transform.Rotate(Vector3.up,rotationSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        
       
        
       
        
        
    }

    private void OnCollisionExit(Collision other)
    {
        
        
        
    }
}
