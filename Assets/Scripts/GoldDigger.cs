using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GoldDigger : MonoBehaviour
{
    public int goldCoin = 0;

    public TextMeshProUGUI coinCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = goldCoin.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Voxel")
        {
            goldCoin++; 
            Destroy(collision.gameObject);
        }
    }
}
