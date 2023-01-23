using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int power = 1;

    public int maxPow = 5;
    // Start is called before the first frame update
    void Start()
    {
        power = PlayerPrefs.GetInt("Power");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
