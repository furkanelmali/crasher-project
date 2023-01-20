using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu,GameMenu;
    public TextMeshProUGUI TotalGoldText; 
    
    public GoldDigger gd;
    public Fuel fuel;
    public MarketSystem ms;
    


    void Update()
    {
        timeScaler();
    }

    public void timeScaler()
    {
        if (MainMenu.gameObject.activeSelf)
        {
            gd.totalCoin = PlayerPrefs.GetInt("Gold");
            TotalGoldText.text = PlayerPrefs.GetInt("Gold").ToString();
            Pause();
        }
        else if(GameMenu.gameObject.activeSelf)
        {
            Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void PlayBtn()
    {
        GameMenu.SetActive(true);
        MainMenu.SetActive(false);
        Resume();
    }

    public void GameOver()
    {
        GameMenu.SetActive(false);
        MainMenu.SetActive(true);
        gd.totalCoin +=  gd.goldCoin;
        PlayerPrefs.SetInt("Gold",gd.totalCoin);
        SceneManager.LoadScene(0);
    }

    public void startingFuelUp()
    {
        if (gd.totalCoin >= ms.fuelPrize && fuel.maxFuel > fuel.currentFuel)
        {
            fuel.currentFuel += 10;
            PlayerPrefs.SetFloat("Fuel",fuel.currentFuel);
            ms.prizeUpdater(ms.fuelPrize);
            PlayerPrefs.SetInt("FuelPrize", ms.fuelPrize);
            gd.totalCoin -= ms.fuelPrize;
            PlayerPrefs.SetInt("Gold", gd.totalCoin);
        }
    }
    
    
    
    
}
