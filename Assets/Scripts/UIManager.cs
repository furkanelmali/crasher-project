using System;
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
    public TextMeshProUGUI FuelPrize, ScalePrize, PowerPrize;
    
    public DesignPatterns.ObjectPolling.GoldDigger gd;
    public Fuel fuel;
    private Power pw;
    public MarketSystem ms;


    private void Start()
    {
        pw = FindObjectOfType<Power>();
    }

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
            FuelPrize.text = PlayerPrefs.GetInt("FuelPrize").ToString();
            PowerPrize.text = PlayerPrefs.GetInt("PowerPrize").ToString();
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
            ms.fuelPrize = ms.prizeUpdater(ms.fuelPrize);
            PlayerPrefs.SetInt("FuelPrize", ms.fuelPrize);
            FuelPrize.text = PlayerPrefs.GetInt("FuelPrize").ToString();
            gd.totalCoin -= ms.fuelPrize;
            PlayerPrefs.SetInt("Gold", gd.totalCoin);
        }
    }

    public void PowerUpgrade()
    {
        
        if (gd.totalCoin >= ms.powerPrize && pw.maxPow > pw.power)
        {
            pw.power += 1;
            PlayerPrefs.SetInt("Power",pw.power);
            ms.powerPrize = ms.prizeUpdater(ms.powerPrize);
            PlayerPrefs.SetInt("PowerPrize",ms.powerPrize);
            PowerPrize.text = PlayerPrefs.GetInt("PowerPrize").ToString();
            gd.totalCoin -= ms.powerPrize;
            PlayerPrefs.SetInt("Gold",gd.totalCoin);

        }

    }
    
    
}
