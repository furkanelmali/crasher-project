using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSystem : MonoBehaviour
{
    public int fuelPrize=110;

    public int scalePrize=200;

    public int powerPrize=250;
    // Start is called before the first frame update
    void Start()
    {
       fuelPrize = PlayerPrefs.GetInt("FuelPrize");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int prizeUpdater(int prize)
    {
        int prizeup = (prize / 100) * 20;
        prize += prizeup;
        Debug.Log("Prize Updated" + prize);
        return prize;
    }
}
