using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountManager : MonoBehaviour
{
    public static AccountManager instance;

    public AccountVO accountVO;

    public Canvas InGameCanvas;
    public Canvas MainStoreCanvas;

    public Text scoreText;
    public Text goldText;
    public Text accountGoldText;

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


    public long accountGold
    {
        get
        {
            Debug.Log( "accountVO.gold " + accountVO.gold);
            return accountVO.gold;
        }
        set
        {            
            accountVO.gold = value;
            SetAccountGoldText();
            Debug.Log("계정 골드 " + accountGold);
        }
    }

    public void SetAccountGoldText()
    {
        accountGoldText.text = accountVO.gold.ToString();
    }



    public void InitVariables()
    {
        // 게임 종료시 변수 초기화
        score = 0;
        gold = 0;        
    }

    public long GetGold()
    {
        long result = (long)Mathf.Sqrt(score) + gold;
        return result;
    }
    public void SetGold()
    {
        accountGold += (long)(GetGold() * accountVO.multiplyGold);
    }

    public void SetScoreText(long __score)
    {
        scoreText.text = __score.ToString();
    }

    public void SetGoldText(long __gold)
    {
        goldText.text = __gold.ToString();
    }

    public void OnGameCanvas()
    {
        InGameCanvas.enabled = true;
        MainStoreCanvas.enabled = false;
    }

    public void OnMainCanvas()
    {
        InGameCanvas.enabled = false;
        MainStoreCanvas.enabled = true;
    }


    void Start()
    {
        if (instance == null)
            instance = this;

        // 계정 로드
        accountVO = SaveSystem.Load("account") as AccountVO;


        SetScoreText(_score);        
        SetAccountGoldText();
        Debug.Log(accountVO.gold + " 골드량");

    }

    

    public void CheckHighestScore(long score)
    {
        if (accountVO.highestScore < score)
            accountVO.highestScore = score;
    }

    public void SaveAccount()
    {
        SaveSystem.Save("account", accountVO);
    }

    private void OnApplicationQuit()
    {
        SaveAccount();
    }

}
