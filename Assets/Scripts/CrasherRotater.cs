using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherRotater : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.rotation.x,transform.rotation.y+rotationSpeed,transform.rotation.z);
    }
}
