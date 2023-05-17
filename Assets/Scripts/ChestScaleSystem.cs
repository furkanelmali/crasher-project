using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScaleSystem : MonoBehaviour
{
    public float chestScale;
    public float maxchestScale;
    public GameObject chest;
    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        maxchestScale = 0.5f;
        uiManager = FindObjectOfType<UIManager>();
        chestScale = uiManager.PlayerPrefsFloatKey("ChestScale",0);
        chestScaler(chestScale);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chestScaler(float scaleRange)
    {
        chest.transform.localScale = new Vector3(chest.transform.localScale.x + scaleRange, chest.transform.localScale.y + scaleRange,chest.transform.localScale.z + scaleRange);
    }
}
