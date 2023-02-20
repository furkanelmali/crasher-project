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

    UIManager uıManager;
    // Start is called before the first frame update
    void Start()
    {
        uıManager = FindObjectOfType<UIManager>();
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
        uıManager.LevelUp();    
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
