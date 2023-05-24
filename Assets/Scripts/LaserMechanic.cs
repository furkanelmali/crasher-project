using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserMechanic : MonoBehaviour
{
    public DynamicJoystick joystick;
    public Transform laserOrigin;
    public GameObject laserRotater;
    public Camera fpsCam;
    public float range = 10f;
    public float duration = 1f;
    public float fireRate = 1f;

    public float rotationspeed = 5f;
    
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
        laserRotaterHandler();
    }

    void processLaser()
    {
        fireTimer += Time.deltaTime;
        if(fireTimer >= fireRate && Input.GetButton("Fire1"))
        {
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            laserLine.SetPosition(1, hit.point);
        }
        else
        {   
            laserLine.SetPosition(1,rayOrigin + (fpsCam.transform.forward * range));
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

    void laserRotaterHandler()
    {
        if(laserRotater.transform.rotation.z < 45f && laserRotater.transform.rotation.z > -45f)
        {laserRotater.transform.Rotate(0,0,joystick.Vertical*rotationspeed);}
    }
}

