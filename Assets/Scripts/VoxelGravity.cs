using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class VoxelGravity : MonoBehaviour
{ 
    public Rigidbody rb;
    public float damageCount = 4;
    public Power power;
    public Sounds sounds;

    public LevelSystem levelsystem;
    
    

    public void Start()
    {   
        rb = GetComponent<Rigidbody>();
        /*power = FindObjectOfType<Power>();
        sounds = FindObjectOfType<Sounds>();
        levelsystem = FindObjectOfType<LevelSystem>();
        this.gameObject.tag = "Voxel";
        rb.isKinematic = true;
        rb.useGravity = false;*/
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

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        
    }   

    
}
    