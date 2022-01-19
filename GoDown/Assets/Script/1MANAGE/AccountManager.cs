using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountManager : MonoBehaviour
{
    public static AccountManager instance;

    public AccountVO accountVO;

    public Text scoreText;

    public long _score;

    public long score
    {
        get
        {
            return _score;
        }
        set
        {            
            _score = value;
            SetScoreText(_score);
        }
    }
    
    public void SetScoreText(long _score)
    {
        scoreText.text = _score.ToString();
    }


    void Start()
    {
        if (instance == null)
            instance = this;

        // 계정 로드
        accountVO = SaveSystem.Load() as AccountVO;

        if(accountVO == null)
        {
            accountVO = new AccountVO();
        }

        // 디버그
        SetScoreText(_score);

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
