using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdmobManager : MonoBehaviour
{
    public static AdmobManager instance;
    public bool isTestMode;
    // public Text LogText;
    // public Button RewardAdsBtn;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadRewardAd();
    }

    void Update()
    {
        //RewardAdsBtn.interactable = rewardAd.IsLoaded();
    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().AddTestDevice("B3ACCBF65750265A").AddTestDevice("1DF7B7CC05014E8").AddTestDevice("a63eaa636c490d9c").Build();
    }



    #region ¹è³Ê ±¤°í
    const string bannerTestID = "ca-app-pub-3940256099942544/6300978111";
    const string bannerID = "";
    BannerView bannerAd;


    void LoadBannerAd()
    {
        bannerAd = new BannerView(isTestMode ? bannerTestID : bannerID,
            AdSize.SmartBanner, AdPosition.Bottom);
        bannerAd.LoadAd(GetAdRequest());
        ToggleBannerAd(false);
    }

    public void ToggleBannerAd(bool b)
    {
        if (b) bannerAd.Show();
        else bannerAd.Hide();
    }
    #endregion


    #region ¸®¿öµå ±¤°í
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "ca-app-pub-5655985157533088/6746225803";
    RewardedAd rewardAd;


    void LoadRewardAd()
    {
        rewardAd = new RewardedAd(isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            //LogText.text = "¸®¿öµå ±¤°í ¼º°ø";

           /* AccountManager.instance.GiveGold(5000);
            AccountManager.instance.SaveAccount();*/
        };
    }

    public void ShowRewardAd()
    {
        rewardAd.IsLoaded();
        rewardAd.Show();
        LoadRewardAd();
    }
    #endregion
}
