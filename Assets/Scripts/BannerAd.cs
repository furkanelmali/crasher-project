using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

    [System.Obsolete]
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

            this.RequestBanner();
      
    }

    public void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
            string adUnitId = "";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }


    

    public void DestroyAd()
{
    if (bannerView != null)
    {
        Debug.Log("Destroying banner ad.");
        bannerView.Destroy();
        bannerView = null;
    }
}

}