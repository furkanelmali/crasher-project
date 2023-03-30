using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;



public class LevelSystem : MonoBehaviour
{
    public int firstVoxelNum;
    public int currentVoxelNum;

    public int destroyedVoxelNum;
    public int currentLevelNum;
    public int unlockedLevelNum;

    public Slider levelBar;
    public bool levelUp;

    UIManager uıManager;
    public Button[] levelButtons;
 
    public GameObject grid;


    // Start is called before the first frame update
   
    void Start()
    {
       
        uıManager = FindObjectOfType<UIManager>();
        
        currentLevelNum = uıManager.PlayerPrefsIntKey("Level", 0);
        unlockedLevelNum = uıManager.PlayerPrefsIntKey("UnlockedLevel", 0);
        

        
        
        findLevelButtons();
        startingSceneActiver();
        buttonEnabler();

        
        firstVoxelNum = transform.childCount;
        currentVoxelNum = transform.childCount;

        levelBar.maxValue = firstVoxelNum;
        levelUp = false;
    }

   public void Update()
   {
        levelBarChanger();
   }

    public void currentVNumChanger()
    {
        currentVoxelNum = transform.childCount;
    }

    public void levelChange()
    {
        if(!levelUp)
        {
            levelUp = true;
            currentLevelNum ++;
            PlayerPrefs.SetInt("Level", currentLevelNum);
            uıManager.LevelUp();  

            if(unlockedLevelNum <= currentLevelNum)
            {
                unlockedLevelNum++;
                PlayerPrefs.SetInt("UnlockedLevel", unlockedLevelNum);
            }

            buttonEnabler();
        }
          
    }

    void levelBarChanger()
    {
        if(currentVoxelNum <= 10)
        {
            levelChange();
        }
        destroyedVoxelNum = firstVoxelNum - currentVoxelNum;
        levelBar.value = destroyedVoxelNum;
    }

    void startingSceneActiver()
    {
        if(SceneManager.GetActiveScene().buildIndex != currentLevelNum)
        {
           SceneManager.LoadScene(currentLevelNum);
        }
    }

    void buttonEnabler()
    {
        for (int i = 0; i < 25; i++)
        {
                 levelButtons[i].interactable = false;
        }

        for(int i = 0; i <= unlockedLevelNum; i++)
        {
                 levelButtons[i].interactable = true;
                
        }
    }

    void findLevelButtons()
    {
        levelButtons = grid.GetComponentsInChildren<Button>();
    }

 
}

