using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelGravity : MonoBehaviour
{ 
    public Rigidbody rb;
    public float damageCount = 4;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    

    private void OnCollisionEnter(Collision other)
    {      
        
    }

    public void damageCheck()
    {
        if (damageCount <= 0)
        {
            Debug.Log("Crash Detected");
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.useGravity = true; 
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Crasher")
        {
            damageCount--;
            damageCheck();
        }
    }
}
    