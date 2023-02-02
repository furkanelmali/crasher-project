using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    UIManager ui;
    public float power = 1;

    public float maxPow = 5;
    // Start is called before the first frame update
    void Start()
    {
        
        ui = FindObjectOfType<UIManager>();
        power= ui.PlayerPrefsFloatKey("Power", .5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
