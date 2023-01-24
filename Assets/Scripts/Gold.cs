using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace DesignPatterns.ObjectPolling
{
    public class Gold : MonoBehaviour
    {
        private IObjectPool<Gold> l_GoldPool;
        public float timee = 10;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

            if (this.gameObject.activeSelf)
            {
                timeChecker();
            }
            
            if (timee <= 0)
            {
                l_GoldPool.Release(this);
                timee = 10;
            }
        }

        private void timeChecker()
        {
            timee -= Time.deltaTime;
        }

        public void SetPool(IObjectPool<Gold> pool)
        {
            l_GoldPool = pool;
        }
    }
}

    