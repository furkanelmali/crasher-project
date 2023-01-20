using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fuel : MonoBehaviour
{
    public float maxFuel = 100;
    
    public Slider FuelBar;
    
    
    public float currentFuel = 30;

    
    // Start is called before the first frame update
    void Start()
    {
        
        FuelBar.maxValue = maxFuel;
        currentFuel = PlayerPrefs.GetFloat("Fuel");
    }

    // Update is called once per frame
    void Update()
    {
        FuelBar.value = currentFuel;
    }

    public void fuelDown()
    {
        currentFuel = currentFuel - Time.deltaTime;
        Debug.Log(currentFuel);
    }
    
    
    
    
    
}
