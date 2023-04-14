using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;


public class IntersAd : MonoBehaviour
{
   InterstitialAd interstitial;
    
    public void requestInterstitial()
    { 
        string _adUnitId;
#if UNITY_ANDROID
        _adUnitId = "ca-app-pub-6369310904606026/3486155491";
#elif UNITY_IPHONE      
        _adUnitId = "ca-app-pub-6369310904606026/2173073829";
#else
        _adUnitId = "unexpected_platform";
#endif

        this.interstitial = new InterstitialAd(_adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);  
    }

    public void showInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
