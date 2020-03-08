using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshButton : MonoBehaviour
{

    private RewardedAd rewardedAd;
    private bool IsEarned = false;

    // Start is called before the first frame update
    void Start()
    {
        CreateAndLoadRewardedAd();
    }

    private void Update()
    {
        if(IsEarned)
        {
            ShopData.RefreshShop();
            IsEarned = false;
        }
    }
    public void CreateAndLoadRewardedAd()
    {
        this.rewardedAd = new RewardedAd("ca-app-pub-4949264892672058/2140200494");

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    }

    private void OnMouseUp()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("sounds/click"));
        if (this.rewardedAd.IsLoaded())
            this.rewardedAd.Show();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        IsEarned = true;
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
    }
}
