using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.Pool;

namespace DesignPatterns.ObjectPolling
{
    public class GoldDigger : MonoBehaviour
    {
        public int totalCoin = 0;
        public int goldCoin = 0;
    
        public Gold[] goldTypes;
        public int[] goldIncomes;
        public Transform spoint;    
    
        public TextMeshProUGUI coinCount;
        private IObjectPool<Gold> GoldPool;
    
    
        private void Awake()
        {
            GoldPool = new ObjectPool<Gold>(CreateGold, OnGetGold,OnReleaseGold,OnDestroyGold,true,10,20);
        }
        
    
        private Gold CreateGold()
        {
            int rand = Random.Range(0, 2);
            Gold spawnedGold = Instantiate(goldTypes[rand],spoint.transform.position,Quaternion.identity);
            spawnedGold.SetPool(GoldPool);
            return spawnedGold;
        }
    
        private void OnGetGold(Gold gold)
        {
            gold.transform.position = spoint.transform.position;
            Rigidbody rb = gold.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0,0,0);
            gold.gameObject.SetActive(true);
        }
        private void OnReleaseGold(Gold gold)
        {
            gold.gameObject.SetActive(false);
        }
        
        private void OnDestroyGold(Gold gold)
        {
            Destroy(gold.gameObject);
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
                goldCoin += goldIncomes[rand];
                GoldPool.Get();
                Destroy(collision.gameObject);
            }
        }
    }
}


