using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherRotater : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private Rigidbody rb;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        transform.rotation= Quaternion.Euler(rot.x,rot.y,rot.z + rotationSpeed*Time.deltaTime);
    }
    
}
