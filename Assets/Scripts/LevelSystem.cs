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

    public Slider levelBar;
    public bool levelUp;

    UIManager uıManager;

    public Scene[] scenes;
 
    // Start is called before the first frame update
   
    void Start()
    {
        uıManager = FindObjectOfType<UIManager>();
        currentLevelNum = uıManager.PlayerPrefsIntKey("Level", 0);
        
        if(SceneManager.GetActiveScene().buildIndex != currentLevelNum)
        {
           SceneManager.LoadScene(currentLevelNum);
        }
       
        
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
}
