using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSystem : MonoBehaviour
{

    UIManager ui;
    Length length;
    public int fuelPrize=110;

    public int scalePrize=500;

    public int powerPrize=250;

    
    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        length = FindObjectOfType<Length>();
        fuelPrize = ui.PlayerPrefsIntKey("FuelPrize", 110);
        scalePrize= ui.PlayerPrefsIntKey("ScalePrize", 500);
        powerPrize= ui.PlayerPrefsIntKey("PowerPrize", 250);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int prizeUpdater(int prize)
    {
        int prizeup = (prize / 100) * 20;
        prize += prizeup;
        
        return prize;
    }
}
