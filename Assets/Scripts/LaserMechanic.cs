using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserMechanic : MonoBehaviour
{
    public Transform laserOrigin;
    public Camera fpsCam;
    public float range = 10f;
    public float duration = 1f;
    public float fireRate = 1f;
    
    float fireTimer;
    LineRenderer laserLine;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        processLaser();
        
    }

    void processLaser()
    {
        fireTimer += Time.deltaTime;
        if(fireTimer >= fireRate && Input.GetButton("Fire1"))
        {
            laserLine.SetPosition(0, laserOrigin.position);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

        }
        else
        {   
            return;
        }
        StartCoroutine(fireLaser());
        fireTimer = 0f;
        }
        
           
       
    }

    IEnumerator fireLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(duration);
        laserLine.enabled = false;
    }
}

