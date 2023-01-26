using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float power = 1;

    public float maxPow = 5;
    // Start is called before the first frame update
    void Start()
    {
        power = PlayerPrefs.GetFloat("Power");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
