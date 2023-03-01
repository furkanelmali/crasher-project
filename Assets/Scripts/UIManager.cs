using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu,GameMenu,GameOverMenu,FinishMenu;
    public TextMeshProUGUI TotalGoldText;
    public TextMeshProUGUI FuelPrize, ScalePrize, PowerPrize;
    
    public DesignPatterns.ObjectPolling.GoldDigger gd;
    public Fuel fuel;
    private Power pw;
    public MarketSystem ms;

    LevelSystem LevelSystem;

    Length length;
    
    public bool isGoldAdded;
    
    private void Start()
    {
        
        LevelSystem = FindObjectOfType<LevelSystem>();
        length  = FindObjectOfType<Length>();
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
            FuelPrize.text = prizeTextChangerFloat(fuel.maxFuel,fuel.currentFuel,PlayerPrefs.GetInt("FuelPrize"));
            PowerPrize.text = prizeTextChangerFloat(pw.maxPow,pw.power,PlayerPrefs.GetInt("PowerPrize"));
            ScalePrize.text = prizeTextChangerInt(length.arms.Length-1,length.armNum,PlayerPrefs.GetInt("ScalePrize"));
            
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
        GameOverMenu.SetActive(true);
        if(!isGoldAdded)
        {   
            isGoldAdded = true;
            gd.totalCoin +=  gd.goldCoin;
            PlayerPrefs.SetInt("Gold",gd.totalCoin);
        }
        Pause();
        
    }

    public void LevelUp()
    {   
        GameMenu.SetActive(false);
        FinishMenu.SetActive(true);
        if(!isGoldAdded)
        {   
            isGoldAdded = true;
            gd.totalCoin +=  gd.goldCoin;
            PlayerPrefs.SetInt("Gold",gd.totalCoin);
        }
        updatereset();
        Pause();
        

    }

    public void startingFuelUp()
    {
        if (gd.totalCoin >= ms.fuelPrize && fuel.maxFuel > fuel.currentFuel)
        {
            fuel.currentFuel += 10;
            PlayerPrefs.SetFloat("Fuel",fuel.currentFuel);
            ms.fuelPrize = ms.prizeUpdater(ms.fuelPrize);
            PlayerPrefs.SetInt("FuelPrize", ms.fuelPrize);
            FuelPrize.text = prizeTextChangerFloat(fuel.maxFuel,fuel.currentFuel,PlayerPrefs.GetInt("FuelPrize"));
            gd.totalCoin -= ms.fuelPrize;
            PlayerPrefs.SetInt("Gold", gd.totalCoin);
        }
    }

    public void PowerUpgrade()
    {
        
        if (gd.totalCoin >= ms.powerPrize && pw.maxPow > pw.power)
        {
            pw.power += 1;
            PlayerPrefs.SetFloat("Power",pw.power);
            ms.powerPrize = ms.prizeUpdater(ms.powerPrize);
            PlayerPrefs.SetInt("PowerPrize",ms.powerPrize);
            PowerPrize.text = prizeTextChangerFloat(pw.maxPow,pw.power,PlayerPrefs.GetInt("PowerPrize"));
            gd.totalCoin -= ms.powerPrize;
            PlayerPrefs.SetInt("Gold",gd.totalCoin);
        }
    }
    
    public void LengthUpgrade()
    {
        if(gd.totalCoin >= ms.scalePrize && length.armNum < length.arms.Length-1)
        {
            length.armNum++;
            length.armChanger();
            gd.totalCoin -= ms.scalePrize;
            ms.scalePrize = ms.prizeUpdater(ms.scalePrize);
            
            PlayerPrefs.SetInt("ScalePrize",ms.scalePrize);
            PlayerPrefs.SetInt("Gold",gd.totalCoin);
            PlayerPrefs.SetInt("ArmNum", length.armNum);
            ScalePrize.text = prizeTextChangerInt(length.arms.Length-1,length.armNum,PlayerPrefs.GetInt("ScalePrize"));

            
        }
    }

    public float PlayerPrefsFloatKey (string key, float defValue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetFloat(key);
        }
        else
        {   
            PlayerPrefs.SetFloat(key, defValue);
            return (float)defValue;
        }
    }


    public int PlayerPrefsIntKey (string key,float defValue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        else
        {
            PlayerPrefs.SetInt(key, (int)defValue);
            return (int)defValue;
        }
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene(LevelSystem.currentLevelNum);
        isGoldAdded = false;
    }

    public string prizeTextChangerFloat(float max, float current, int prize)
    {
        if (max > current)
        {
           string prizet = prize.ToString();
           return prizet;
        }
        else
        {
            return "MAX";
        }
    }

    public string prizeTextChangerInt(int max, int current, int prize)
    {
        if (max > current)
        {
            string prizet = prize.ToString();
            return prizet;
        }
        else
        {
            return "MAX";
        }
    }

    void updatereset()
    {
        PlayerPrefs.DeleteKey("Fuel");
        PlayerPrefs.DeleteKey("Power");
        PlayerPrefs.DeleteKey("Scale");
        PlayerPrefs.DeleteKey("FuelPrize");
        PlayerPrefs.DeleteKey("PowerPrize");
        PlayerPrefs.DeleteKey("ScalePrize");
    }


}
