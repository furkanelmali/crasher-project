using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GoldDigger : MonoBehaviour
{
    public int goldCoin = 0;

    public GameObject[] goldTypes;
    public int[] goldIncomes;
    public Transform spoint;    

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
            int rand = Random.Range(0, 2);
            goldCoin = goldCoin + goldIncomes[rand];
            GameObject spawnedGold = Instantiate(goldTypes[rand],spoint.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
