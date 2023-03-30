using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Length : MonoBehaviour
{
    public GameObject[] arms;
    public int armNum = 0;

    UIManager uıManager;

    // Start is called before the first frame update
    
    
    void Start()
    {
        
        uıManager = FindObjectOfType<UIManager>();
        armNum = uıManager.PlayerPrefsIntKey("ArmNum", 0);
        startArmActiver();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void armChanger()
    {
        arms[armNum-1].SetActive(false);
        arms[armNum].SetActive(true);
        
    }

    public void startArmActiver()
    {   
        
        arms[0].SetActive(false);
        
        arms[armNum].SetActive(true);
        
    }
}
