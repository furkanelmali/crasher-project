using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fuel : MonoBehaviour
{
    public float maxFuel = 100; 
    public float fuelDownNum;
    UIManager ui;
    
    public Slider FuelBar; //Showing fuel at the UI
    
    
    public float currentFuel = 30;

    
    // Start is called before the first frame update
    void Start()
    {
        
        ui = FindObjectOfType<UIManager>();
        FuelBar.maxValue = maxFuel;

        currentFuel  = ui.PlayerPrefsFloatKey("Fuel", 30);
        fuelDownNum = ui.PlayerPrefsFloatKey("FuelDown", 1);
    
    }

    // Update is called once per frame
    void Update()
    {
        FuelBar.value = currentFuel;
    }

    public void fuelDown()
    {
        currentFuel = currentFuel - (fuelDownNum * Time.deltaTime);
        Debug.Log(currentFuel);
    }
    
    
    
    
    
}
