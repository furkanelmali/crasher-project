using System.Threading.Tasks;
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
    public GameObject MainMenu,GameMenu,GameOverMenu,FinishMenu,LevelMenu,TutorialMenu,PauseMenu,ShopMenu;
    public TextMeshProUGUI TotalGoldText,EndLevelGoldText, ShopGoldText;
    public TextMeshProUGUI FuelPrize, ScalePrize, PowerPrize, LevelText, chestScalePrizeText;
    
    public Rigidbody characterrb;
    public GameObject[] tutorialPages;
    
   
    public int isfirstOpen;
    public int tutorialpageNum;
    public DesignPatterns.ObjectPolling.GoldDigger gd;
    public Fuel fuel;
    private Power pw;
     
    adReward adReward;
    IntersAd intersAd;
    BannerAd banner;

    ChestAnimator chestAnimator;

    ChestScaleSystem chestScaleSystem;

    LoadingPanel loadingPanel;
    public MarketSystem ms;

    Sounds sounds;

    LevelSystem levelSystem;

    Length length;
    
    Controller controller;
    
    public bool isGoldAdded;
    
    private void Start()
    {   
        levelSystem = FindObjectOfType<LevelSystem>();
        length  = FindObjectOfType<Length>();
        pw = FindObjectOfType<Power>();
        sounds = FindObjectOfType<Sounds>();
        adReward = FindObjectOfType<adReward>();
        intersAd = FindObjectOfType<IntersAd>();
        banner = FindObjectOfType<BannerAd>();
        controller = FindObjectOfType<Controller>();
        loadingPanel = FindObjectOfType<LoadingPanel>();
        gd = FindObjectOfType<DesignPatterns.ObjectPolling.GoldDigger>();
        chestAnimator = FindObjectOfType<ChestAnimator>();
        chestScaleSystem = FindObjectOfType<ChestScaleSystem>();
       
        isfirstOpen = PlayerPrefsIntKey("isfirstOpen",1);
        
        gd.totalCoin = PlayerPrefsFloatKey("Gold",0);

        if(isfirstOpen == 1)
        {
            tutorialMenuActive();
        }
        else
        {
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                MainMenu.SetActive(true);
            }
            else
            {
                GameMenu.SetActive(true);
                intersAd.requestInterstitial();
            }
            
        }

        
    }

    void Update()
    {
        timeScaler();
    }

    public void timeScaler()
    {
        if (MainMenu.gameObject.activeSelf)
        {
            
            TotalGoldText.text = ((int)gd.totalCoin).ToString();
            FuelPrize.text = prizeTextChangerFloat(fuel.maxFuel,fuel.currentFuel,PlayerPrefs.GetInt("FuelPrize"));
            PowerPrize.text = prizeTextChangerFloat(pw.maxPow,pw.power,PlayerPrefs.GetInt("PowerPrize"));
            ScalePrize.text = prizeTextChangerInt(length.arms.Length-1,length.armNum,PlayerPrefs.GetInt("ScalePrize"));
            
            Pause();
        }
        else if(GameMenu.gameObject.activeSelf)
        {
            Resume();
            TotalGoldText.text = ((int)gd.totalCoin).ToString();
            LevelText.text = "Level" +" " +(levelSystem.currentLevelNum).ToString();
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
        // GameMenu.SetActive(true);
        // MainMenu.SetActive(false);
        MainMenu.SetActive(false);
        banner.DestroyAd();
        SceneManager.LoadScene(levelSystem.currentLevelNum);
        Resume();
        
    }

    public async void  GameOver()
    {
        chestAnimator.closeChest();
        GameMenu.SetActive(false);
        GameOverMenu.SetActive(true);
        EndLevelGoldText.text = ((int)gd.goldCoin).ToString();
        adReward.loadingAd();
        //characterrb.velocity = new Vector3(0,0,0);

                    
    }

    public void LevelUp()
    {   
        chestAnimator.closeChest();
        GameMenu.SetActive(false);
        FinishMenu.SetActive(true);
        updatereset();
        
        intersAd.showInterstitial();
    }

    public void startingFuelUp()
    {
        if (gd.totalCoin >= ms.fuelPrize && fuel.maxFuel > fuel.currentFuel)
        {
            fuel.currentFuel += 10;
            PlayerPrefs.SetFloat("Fuel",fuel.currentFuel);
            gd.totalCoin -= ms.fuelPrize;
            PlayerPrefs.SetFloat("Gold", gd.totalCoin);
            ms.fuelPrize = ms.prizeUpdater(ms.fuelPrize);
            PlayerPrefs.SetInt("FuelPrize", ms.fuelPrize);
            FuelPrize.text = prizeTextChangerFloat(fuel.maxFuel,fuel.currentFuel,PlayerPrefs.GetInt("FuelPrize"));
            
        }
    }

    public void PowerUpgrade()
    {
        
        if (gd.totalCoin >= ms.powerPrize && pw.maxPow > pw.power)
        {
            pw.power += 1;
            fuel.fuelDownNum -= 0.05f;
            PlayerPrefs.SetFloat("FuelDown",fuel.fuelDownNum);
            PlayerPrefs.SetFloat("Power",pw.power);
            PowerPrize.text = prizeTextChangerFloat(pw.maxPow,pw.power,PlayerPrefs.GetInt("PowerPrize"));
            gd.totalCoin -= ms.powerPrize;
            ms.powerPrize = ms.prizeUpdater(ms.powerPrize);
            PlayerPrefs.SetInt("PowerPrize",ms.powerPrize);
            PlayerPrefs.SetFloat("Gold",gd.totalCoin);
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
            PlayerPrefs.SetFloat("Gold",gd.totalCoin);
            PlayerPrefs.SetInt("ArmNum", length.armNum);
            ScalePrize.text = prizeTextChangerInt(length.arms.Length-1,length.armNum,PlayerPrefs.GetInt("ScalePrize"));
        }
    }

    public void ChestScaleUpgrade()
    {
        if(gd.totalCoin >= ms.chessScalePrize && chestScaleSystem.chestScale < chestScaleSystem.maxchestScale)
        {
            Debug.Log("Scaling");
            gd.totalCoin -= ms.chessScalePrize;
            ms.chessScalePrize = ms.prizeUpdater(ms.chessScalePrize);

            chestScaleSystem.chestScale += .1f;
            chestScaleSystem.chestScaler(chestScaleSystem.chestScale);

            

            PlayerPrefs.SetFloat("ChestScale",chestScaleSystem.chestScale);
            PlayerPrefs.SetFloat("Gold",gd.totalCoin);
            PlayerPrefs.SetInt("ChessScalePrize",ms.chessScalePrize);
            chestScalePrizeText.text = ms.chessScalePrize.ToString();
            ShopGoldText.text = ((int)gd.totalCoin).ToString();
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
        if(!isGoldAdded)
        {  
            isGoldAdded = true;
            gd.totalCoin =gd.totalCoin + gd.goldCoin;
            PlayerPrefs.SetFloat("Gold",gd.totalCoin);
        }
        banner.DestroyAd();
        SceneManager.LoadScene(0);
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
        PlayerPrefs.DeleteKey("FuelDown");
        PlayerPrefs.DeleteKey("Fuel");
        PlayerPrefs.DeleteKey("Power");
        PlayerPrefs.DeleteKey("ArmNum");
        PlayerPrefs.DeleteKey("FuelPrize");
        PlayerPrefs.DeleteKey("PowerPrize");
        PlayerPrefs.DeleteKey("ScalePrize");
    }

    public void LevelMenuBtn()
    {  
        LevelMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void shopMenuBtn()
    {
        ShopMenu.SetActive(true);
        MainMenu.SetActive(false);
        ShopGoldText.text = ((int)gd.totalCoin).ToString();
    }

    public void levelButton(int levelNum)
    {
        levelSystem.currentLevelNum = levelNum;
        PlayerPrefs.SetInt("Level", levelSystem.currentLevelNum);
        LevelMenu.SetActive(false);
        SceneManager.LoadScene(levelSystem.currentLevelNum);
        Resume();
    }

    
    public void tutorialController()
    {
        if(tutorialPages[0].active)
        {
            tutorialPages[0].SetActive(false);
            tutorialPages[1].SetActive(true);
        }
        else if(tutorialPages[1].active)
        {
            tutorialPages[1].SetActive(false);
            tutorialPages[2].SetActive(true);
        }
        else if(tutorialPages[2].active)
        {
            tutorialPages[2].SetActive(false);
            tutorialPages[3].SetActive(true);
        }
        else if(tutorialPages[3].active)
        {
            tutorialPages[3].SetActive(false);
            tutorialPages[4].SetActive(true);
        }
        else if(tutorialPages[4].active)
        {
            TutorialMenu.SetActive(false);
            MainMenu.SetActive(true);
           
        }

    }

    public void tutorialMenuActive()
    {
            TutorialMenu.SetActive(true);
            MainMenu.SetActive(false);
            Pause();
            PlayerPrefs.SetInt("isfirstOpen",0);
    }

  

    public void backToMainMenu()
    {
        LevelMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void backToGame()
    {
        GameMenu.SetActive(true);
        PauseMenu.SetActive(false);
        Resume();
    }

    public void backToShop()
    {
        ShopMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void PauseBtn()
    {
        GameMenu.SetActive(false);
        PauseMenu.SetActive(true);
        
        Pause();
    }

    public void Restart()
    {
        GameOverMenu.SetActive(false);
        banner.DestroyAd();
        SceneManager.LoadScene(levelSystem.currentLevelNum);
        Resume();
        
    }

    
}
