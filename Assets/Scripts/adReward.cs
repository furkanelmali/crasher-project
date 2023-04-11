using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class adReward : MonoBehaviour
{
      private RewardedAd rewardedAd;
      private Fuel fuel;

      private UIManager uı;

    void Start() 
    {
            fuel = FindObjectOfType<Fuel>();
            uı = FindObjectOfType<UIManager>();
    }


    public void loadingAd()
    {
        // These ad units are configured to always serve test ads.
        string _adUnitId;
#if UNITY_ANDROID
        _adUnitId = "ca-app-pub-6369310904606026/9095531826";
#elif UNITY_IPHONE
        _adUnitId = "ca-app-pub-6369310904606026/3923096199";
#else
        _adUnitId = "unused";
#endif

         this.rewardedAd = new RewardedAd(_adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);

    }

    public void showAd(int i)
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
            this.rewardedAd.OnUserEarnedReward += i == 1 ? giveReward : giveReward2;
            this.rewardedAd.OnAdClosed += (sender, args) =>
            {
                if(i == 1)
                 uı.Resume();
            };
        }
    }

 
 
    public void giveReward(object sender, Reward args)
    {
        Debug.Log("Reward");
        fuel.currentFuel = 30;
         uı.GameOverMenu.SetActive(false);
        uı.GameMenu.SetActive(true);
        // uı.Resume();
    }

    public void giveReward2(object sender, Reward args)
    {
        Debug.Log("Reward");
        uı.gd.goldCoin = uı.gd.goldCoin *2;
        uı.MainMenu.SetActive(true);
        uı.GameOverMenu.SetActive(false);
        
        // uı.Resume();
    }

    
}