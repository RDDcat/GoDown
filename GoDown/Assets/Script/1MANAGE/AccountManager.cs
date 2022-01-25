using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountManager : MonoBehaviour
{
    public static AccountManager instance;

    public AccountVO accountVO;

    public Text scoreText;
    public Text goldText;

    public long _score;
    public long _gold;
    public float multiplyGold;

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

    public long gold
    {
        get
        {
            return _gold;
        }
        set
        {
            _gold = value;
        }
    }

    public void InitVariables()
    {
        // 게임 종료시 변수 초기화
        score = 0;
        gold = 0;
    }

    public void SaveGold()
    {
        accountVO.gold += _gold;
    }

    public long GetGold()
    {
        long result = (long)Mathf.Sqrt(score) + _gold;
        return result;
    }

    public void SetScoreText(long __score)
    {
        scoreText.text = __score.ToString();
    }

    public void SetGoldText(long __gold)
    {
        goldText.text = __gold.ToString();
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

    public void SetGold()
    {
        accountVO.gold = (long)(gold * accountVO.multiplyGold);

    }

    public void CheckHighestScore(long score)
    {
        if (accountVO.highestScore < score)
            accountVO.highestScore = score;
    }




}
