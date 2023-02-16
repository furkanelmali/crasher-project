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
    public int currentLevelNum = 0;

    public Slider levelBar;

    UIManager uı;
    // Start is called before the first frame update
    void Start()
    {
        uı = FindObjectOfType<UIManager>();
        firstVoxelNum = transform.childCount;
        currentVoxelNum = transform.childCount;

        levelBar.maxValue = firstVoxelNum;
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
        currentLevelNum ++;
    }

    void levelBarChanger()
    {
        if(currentVoxelNum <= 100)
        {
            levelUpScene();
        }
        else
        {
            destroyedVoxelNum = firstVoxelNum - currentVoxelNum;
            levelBar.value = destroyedVoxelNum;
        }
        
    }

    void levelUpScene()
    {
            uı.LevelUpScene();
            levelChange();
    }
}
