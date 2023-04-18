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
        if(this.bannerView == null){
            this.RequestBanner();
        }
        
      
    }

    public void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-6369310904606026/4226348529";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-6369310904606026/4773143436";
        #else
            string adUnitId = "unexpected_platform";
        #endif
        
        Debug.Log("Requesting banner ad.");
        Debug.Log(adUnitId);

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