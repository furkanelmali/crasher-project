using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelGravity : MonoBehaviour
{ 
    public Rigidbody rb;
    public float health;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision other)
    {      
        if (other.gameObject.tag == "Crasher")
        {
            Debug.Log("Crash Detected");
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.useGravity = true;
        }
    }

   
    
}
    