using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BannerAdMob : MonoBehaviour
{

    private int scoreAdReward;

    string bannerAdUnitId = "f4883f53e5ddd3cb";
    string intersicialUnitId = "d651db7115d8f6d4";
    string rewardUnitId = "2e1eed1ffb6aa580";

    int retryAttempt;

    //ca-app-pub-3120121289944186/2529644622 banner real
    //ca-app-pub-3120121289944186/6041019385 Intersical real
    //ca-app-pub-3120121289944186/8386623226 adReward real

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("ads") == 0)
        {
            this.RequestBanner();
            this.RequestInterstitial();
            this.RequestAdReward();
        }
    
    }

    private void RequestBanner()
    {

        // Adaptive banners are sized based on device width for positions that stretch full width (TopCenter and BottomCenter).
    // You may use the utility method `MaxSdkUtils.GetAdaptiveBannerHeight()` to help with view sizing adjustments
        MaxSdk.CreateBanner(bannerAdUnitId, MaxSdkBase.BannerPosition.BottomCenter);
        MaxSdk.SetBannerExtraParameter(bannerAdUnitId, "adaptive_banner", "true");

        MaxSdk.ShowBanner(bannerAdUnitId);

    }

    private void RequestInterstitial()
    {

        

         // Attach callback
    MaxSdkCallbacks.OnInterstitialLoadedEvent += OnInterstitialLoadedEvent;
    MaxSdkCallbacks.OnInterstitialLoadFailedEvent += OnInterstitialFailedEvent;
    MaxSdkCallbacks.OnInterstitialAdFailedToDisplayEvent += InterstitialFailedToDisplayEvent;
    MaxSdkCallbacks.OnInterstitialHiddenEvent += OnInterstitialDismissedEvent;

    // Load the first interstitial
    LoadInterstitial();

    }

    private void RequestAdReward()
    {

        // Attach callback
    MaxSdkCallbacks.OnRewardedAdLoadedEvent += OnRewardedAdLoadedEvent;
    MaxSdkCallbacks.OnRewardedAdLoadFailedEvent += OnRewardedAdFailedEvent;
    MaxSdkCallbacks.OnRewardedAdFailedToDisplayEvent += OnRewardedAdFailedToDisplayEvent;
    MaxSdkCallbacks.OnRewardedAdDisplayedEvent += OnRewardedAdDisplayedEvent;
    MaxSdkCallbacks.OnRewardedAdClickedEvent += OnRewardedAdClickedEvent;
    MaxSdkCallbacks.OnRewardedAdHiddenEvent += OnRewardedAdDismissedEvent;
    MaxSdkCallbacks.OnRewardedAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

    // Load the first rewarded ad
    LoadRewardedAd();

    }

    private void LoadRewardedAd()
{
    MaxSdk.LoadRewardedAd(rewardUnitId);
}

private void OnRewardedAdLoadedEvent(string adUnitId)
{
    // Rewarded ad is ready to be shown. MaxSdk.IsRewardedAdReady(adUnitId) will now return 'true'

    // Reset retry attempt
    retryAttempt = 0;
}

private void OnRewardedAdFailedEvent(string adUnitId, int errorCode)
{
    // Rewarded ad failed to load 
    // We recommend retrying with exponentially higher delays up to a maximum delay (in this case 64 seconds)

    retryAttempt++;
    double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));
    
    Invoke("LoadRewardedAd", (float) retryDelay);
}

private void OnRewardedAdFailedToDisplayEvent(string adUnitId, int errorCode)
{
    // Rewarded ad failed to display. We recommend loading the next ad
    LoadRewardedAd();
}

private void OnRewardedAdDisplayedEvent(string adUnitId) {}

private void OnRewardedAdClickedEvent(string adUnitId) {}

private void OnRewardedAdDismissedEvent(string adUnitId)
{
    // Rewarded ad is hidden. Pre-load the next ad
    LoadRewardedAd();
}

private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward)
{
    // Rewarded ad was displayed and user should receive the reward
}


//-----------------------INTERSICIAL------------------------------------

    private void LoadInterstitial()
{
    MaxSdk.LoadInterstitial(intersicialUnitId);
}

private void OnInterstitialLoadedEvent(string adUnitId)
{
    // Interstitial ad is ready to be shown. MaxSdk.IsInterstitialReady(adUnitId) will now return 'true'

    // Reset retry attempt
    retryAttempt = 0;
}

private void OnInterstitialFailedEvent(string adUnitId, int errorCode)
{
    // Interstitial ad failed to load 
    // We recommend retrying with exponentially higher delays up to a maximum delay (in this case 64 seconds)

    retryAttempt++;
    double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));
    
    Invoke("LoadInterstitial", (float) retryDelay);
}

private void InterstitialFailedToDisplayEvent(string adUnitId, int errorCode)
{
    // Interstitial ad failed to display. We recommend loading the next ad
    LoadInterstitial();
}

private void OnInterstitialDismissedEvent(string adUnitId)
{
    // Interstitial ad is hidden. Pre-load the next ad
    LoadInterstitial();
}


}

