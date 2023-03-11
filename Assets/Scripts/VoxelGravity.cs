using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class VoxelGravity : MonoBehaviour
{ 
    public Rigidbody rb;
    public float damageCount = 4;
    public Power power;
    Sounds sounds;

    private LevelSystem levelsystem;
    
    

    private void Start()
    {
        this.gameObject.tag = "Voxel";
        rb = GetComponent<Rigidbody>();
        power = FindObjectOfType<Power>();
        sounds = FindObjectOfType<Sounds>();
        levelsystem = FindObjectOfType<LevelSystem>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    

    private void OnCollisionEnter(Collision other)
    {      
        if(other.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
            levelsystem.currentVNumChanger();
        }
       
    }

    public void damageCheck()
    {
        if (damageCount <= 0)
        {
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.useGravity = true;
            sounds.crushSound();
           
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Crasher" && damageCount >= 0)
        {
            damageCount -= power.power;
            damageCheck();
        }
    }
}
    