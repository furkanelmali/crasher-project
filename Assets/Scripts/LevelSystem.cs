using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int firstVoxelNum;
    public int currentVoxelNum;
    public int currentLevelNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        firstVoxelNum = transform.childCount;
        currentVoxelNum = transform.childCount;
    }

   

    public void currentVNumChanger()
    {
        currentVoxelNum = transform.childCount;
    }

    public void levelChange()
    {
        currentLevelNum ++;
    }
}
