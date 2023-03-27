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
        _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        _adUnitId = "unused";
#endif

         this.rewardedAd = new RewardedAd(_adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);

    }

    public void showAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
            this.rewardedAd.OnUserEarnedReward += giveReward;
        }
    }
 
    public void giveReward(object sender, Reward args)
    {
        Debug.Log("Reward");
        fuel.currentFuel = 30;
        uı.GameOverMenu.SetActive(false);
        uı.GameMenu.SetActive(true);
        uı.Resume();
    }
}