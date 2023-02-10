using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Length : MonoBehaviour
{
    public GameObject[] arms;
    public int armNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        armNum = 0;
        PlayerPrefs.SetInt("ArmNum", armNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void armChanger()
    {
        arms[armNum-1].SetActive(false);
        arms[armNum].SetActive(true);
        PlayerPrefs.SetInt("ArmNum", armNum);
    }
}
