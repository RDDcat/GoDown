using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAD : MonoBehaviour
{
    public void showAD()
    {
        AdmobManager.instance.ShowRewardAd();
        Debug.Log("����");
        AccountManager.instance.GiveGold(5000);
        Debug.Log("������");
        AccountManager.instance.SaveAccount();
        Debug.Log("������");
    }

}
