using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAD : MonoBehaviour
{
    AdmobManager admobManager;

    public void Awake()
    {
    }

    public void showAD()
    {
        admobManager.ShowRewardAd();
    }

}
