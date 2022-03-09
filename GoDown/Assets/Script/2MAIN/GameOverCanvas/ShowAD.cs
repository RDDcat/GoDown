using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAD : MonoBehaviour
{
    public void showAD()
    {
        AdmobManager.instance.ShowRewardAd();
        Debug.Log("±¤°í");
        AccountManager.instance.GiveGold(5000);
        Debug.Log("µ·Áö±Þ");
        AccountManager.instance.SaveAccount();
        Debug.Log("µ·ÀúÀå");
    }

}
