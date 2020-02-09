using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshButton : MonoBehaviour
{

    private RewardedAd rewardedAd;

    // Start is called before the first frame update
    void Start()
    {
        CreateAndLoadRewardedAd();
    }

    public void CreateAndLoadRewardedAd()
    {
        this.rewardedAd = new RewardedAd("ca-app-pub-4949264892672058/2140200494");

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    }

    private void OnMouseUp()
    {
        if (this.rewardedAd.IsLoaded())
            this.rewardedAd.Show();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        ShopData.RefreshShop();
        ShopManager.current = 1;
        ShopManager.toBe = 0;
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {

    }
}
