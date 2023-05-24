using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelChanger : MonoBehaviour
{
    public UIManager uiManager;
    public DesignPatterns.ObjectPolling.GoldDigger gd;
    
    public bool[] unlockedWheels;
    public int currentWheel;
    public int choosedWheel;

    public int[] wheelPrizes;
    public Mesh[] wheelMeshes;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI prizeText;

    public MeshFilter[] wheelObjects;
    public MeshCollider[] wheelColliders;



    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        
        
        currentWheel = uiManager.PlayerPrefsIntKey("CurrentWheel", 0);
        choosedWheel = uiManager.PlayerPrefsIntKey("ChoosedWheel", 0);
        buyedCheck();
        wheelMeshChanger();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void forwardBtn()
    {
        currentWheel++; 
        if (unlockedWheels[currentWheel])
        {
            buttonText.text = "choose";
            prizeText.text = wheelPrizes[currentWheel].ToString();
            if(currentWheel == choosedWheel)
            {
            buttonText.text = "choosed";
            prizeText.text = "buyed";
            }
        }
        else
        {
            buttonText.text = "buy";
            prizeText.text = wheelPrizes[currentWheel].ToString();
        }
         
    }

    public void backBtn()
    {
        currentWheel--; 
        if (unlockedWheels[currentWheel])
        {
            buttonText.text = "choose";
            prizeText.text = wheelPrizes[currentWheel].ToString();
            if(currentWheel == choosedWheel)
             {
            buttonText.text = "choosed";
            prizeText.text = "buyed";
             }
        }
        else
        {
            buttonText.text = "buy";
            prizeText.text = wheelPrizes[currentWheel].ToString();
        }
        
    }

    public void buyBtn()
    {

        if(unlockedWheels[currentWheel])
        {
            buttonText.text = "choosed";
            choosedWheel = currentWheel;
            PlayerPrefs.SetInt("ChoosedWheel", choosedWheel);
            wheelMeshChanger();
        }
        else 
        {
            if(gd.totalCoin >= wheelPrizes[currentWheel])
            {
                Debug.Log("buyed");
                buttonText.text = "choose";
                gd.totalCoin -= wheelPrizes[currentWheel];
                uiManager.ShopGoldText.text = gd.totalCoin.ToString();
                PlayerPrefs.SetFloat("Gold", gd.totalCoin);
                unlockedWheels[currentWheel] = true;
                PlayerPrefs.SetInt("UnlockedWheel" + currentWheel, Convert.ToInt32(unlockedWheels[currentWheel]));
            }
            
        }   
        
    }

    void buyedCheck()
    {
        for(int i = 0; i < unlockedWheels.Length; i++)
        {
            if(i == 0)
            {
                unlockedWheels[i] = uiManager.PlayerPrefsBoolKey("UnlockedWheel" + i, true);
            }
        
            unlockedWheels[i] = uiManager.PlayerPrefsBoolKey("UnlockedWheel" + i,   false);
        }
    }

    void wheelMeshChanger()
    {
        for(int i = 0; i <= 2; i++)
        {
            wheelObjects[i].mesh = wheelMeshes[choosedWheel];
            wheelColliders[i].sharedMesh = wheelMeshes[choosedWheel];
        }
    }
}
