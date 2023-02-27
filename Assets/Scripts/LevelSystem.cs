using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int firstVoxelNum;
    public int currentVoxelNum;

    public int destroyedVoxelNum;
    public int currentLevelNum;

    public Slider levelBar;
    public bool levelUp;

    UIManager uıManager;
    // Start is called before the first frame update
    void Awake()
    {
        uıManager = FindObjectOfType<UIManager>();
        currentLevelNum = uıManager.PlayerPrefsIntKey("Level", 0);
        
    }
    void Start()
    {
        
        
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
