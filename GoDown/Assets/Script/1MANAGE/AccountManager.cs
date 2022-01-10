using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public static AccountManager instance;

    public AccountVO accountVO;


    void Start()
    {
        // 계정 로드
        accountVO = SaveSystem.Load() as AccountVO;




    }

    public void AddMoney(long money)
    {
        accountVO.money += money;
    }

    public void CheckHighestScore(long score)
    {
        if (accountVO.highestScore < score)
            accountVO.highestScore = score;
    }
    
}
