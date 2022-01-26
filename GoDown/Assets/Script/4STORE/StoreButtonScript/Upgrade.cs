using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    // 게임 메니저    
    public float blockAccel; // 가속도    
    public float blockSpeedLimit; // 최고속도 (게이지 최대치)
    public float blockSpeed; // 시작속도
    public float blockResistance; // 데미지 저항

    // 모바일 터치
    public float playerSpeed; // 플레이어 좌우속도
    public float multiplyGold; // 1.xx 배


    // 골드 텍스트 받기
    public TextMeshProUGUI blockAccelText;
    public TextMeshProUGUI blockSpeedLimitText;
    public TextMeshProUGUI blockSpeedText;    
    public TextMeshProUGUI playerSpeedText;
    public TextMeshProUGUI blockResistanceText;
    public TextMeshProUGUI multiplyGoldText;

    // 레벨 텍스트 받기
    public TextMeshProUGUI blockAccelLevelText;
    public TextMeshProUGUI blockSpeedLimitLevelText;
    public TextMeshProUGUI blockSpeedLevelText;
    public TextMeshProUGUI playerSpeedLevelText;
    public TextMeshProUGUI blockResistanceLevelText;
    public TextMeshProUGUI multiplyGoldLevelText;

    private void Start()
    {
        // 텍스트 초기화
        blockAccelText.text = ((AccountManager.instance.accountVO.Upgrade1 + 1) * 10).ToString();
        blockSpeedLimitText.text = ((AccountManager.instance.accountVO.Upgrade2 + 1) * 10).ToString();
        blockSpeedText.text = ((AccountManager.instance.accountVO.Upgrade3 + 1) * 10).ToString();
        playerSpeedText.text = ((AccountManager.instance.accountVO.Upgrade4 + 1) * 10).ToString();
        blockResistanceText.text = ((AccountManager.instance.accountVO.Upgrade5 + 1) * 10).ToString();
        multiplyGoldText.text = ((AccountManager.instance.accountVO.Upgrade6 + 1) * 10).ToString();

        blockAccelLevelText.text = AccountManager.instance.accountVO.Upgrade1.ToString();
        blockSpeedLimitLevelText.text = AccountManager.instance.accountVO.Upgrade2.ToString();
        blockSpeedLevelText.text = AccountManager.instance.accountVO.Upgrade3.ToString();
        playerSpeedLevelText.text = AccountManager.instance.accountVO.Upgrade4.ToString();
        blockResistanceLevelText.text = AccountManager.instance.accountVO.Upgrade5.ToString();
        multiplyGoldLevelText.text = AccountManager.instance.accountVO.Upgrade6.ToString();
    }

    public void UpgradeBlockAccel()
    {
        // 만약 돈이 없다면 스킵
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade1 * 10)
        {            
            return;
        }
        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // 돈소모
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade1 * 10;

        // 업그레이드 저장
        AccountManager.instance.accountVO.Upgrade1 += 1;

        // 다음소모치 텍스트 업데이트
        blockAccelText.text = ((AccountManager.instance.accountVO.Upgrade1 + 1) * 10).ToString();

        // 강화
        AccountManager.instance.accountVO.blockSpeed += blockSpeed;

        blockAccelLevelText.text = AccountManager.instance.accountVO.Upgrade1.ToString();

        SaveUpgradeDate();
    }

    public void UpgradeBlockSpeedLimit()
    {
        // 만약 돈이 없다면 스킵
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade2 * 10)
        {
            return;
        }
        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // 돈소모
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade2 * 10;

        // 업그레이드 저장
        AccountManager.instance.accountVO.Upgrade2 += 1;

        // 다음소모치 텍스트 업데이트
        blockSpeedLimitText.text = ((AccountManager.instance.accountVO.Upgrade2 + 1) * 10).ToString();

        AccountManager.instance.accountVO.blockSpeedLimit += blockSpeedLimit;

        blockSpeedLimitLevelText.text = AccountManager.instance.accountVO.Upgrade2.ToString();

        SaveUpgradeDate();
    }

    public void UpgradeBlockSpeed()
    {
        // 만약 돈이 없다면 스킵
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade3 * 10)
        {            
            return;
        }
        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // 돈소모
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade3 * 10;

        // 업그레이드 저장
        AccountManager.instance.accountVO.Upgrade3 += 1;

        // 다음소모치 텍스트 업데이트
        blockSpeedText.text = ((AccountManager.instance.accountVO.Upgrade3 + 1) * 10).ToString();

        // 강화
        AccountManager.instance.accountVO.blockSpeed += blockSpeed;

        blockSpeedLevelText.text = AccountManager.instance.accountVO.Upgrade3.ToString();

        SaveUpgradeDate();
    }

    
    public void UpgradePlayerSpeed()
    {
        // 만약 돈이 없다면 스킵
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade4 * 10)
        {
            return;
        }
        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // 돈소모
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade4 * 10;

        // 업그레이드 저장
        AccountManager.instance.accountVO.Upgrade4 += 1;

        // 다음소모치 텍스트 업데이트
        playerSpeedText.text = ((AccountManager.instance.accountVO.Upgrade4 + 1) * 10).ToString();

        AccountManager.instance.accountVO.playerSpeed += playerSpeed;

        playerSpeedLevelText.text = AccountManager.instance.accountVO.Upgrade4.ToString();

        SaveUpgradeDate();
    }


    public void UpgradeBlockResistance()
    {
        // 만약 돈이 없다면 스킵
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade5 * 10)
        {
            return;
        }
        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // 돈소모
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade5 * 10;

        // 업그레이드 저장
        AccountManager.instance.accountVO.Upgrade5 += 1;

        // 다음소모치 텍스트 업데이트
        blockResistanceText.text = ((AccountManager.instance.accountVO.Upgrade5 + 1) * 10).ToString();

        AccountManager.instance.accountVO.blockResistance += blockResistance;

        blockResistanceLevelText.text = AccountManager.instance.accountVO.Upgrade5.ToString();

        SaveUpgradeDate();
    }


    public void UpgradeMultiplyGold()
    {
        // 만약 돈이 없다면 스킵
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade6 * 10)
        {
            return;
        }
        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // 돈소모
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade6 * 10;

        // 업그레이드 저장
        AccountManager.instance.accountVO.Upgrade6 += 1;

        // 다음소모치 텍스트 업데이트
        multiplyGoldText.text = ((AccountManager.instance.accountVO.Upgrade6 + 1) * 10).ToString();

        AccountManager.instance.accountVO.multiplyGold += multiplyGold;

        multiplyGoldLevelText.text = AccountManager.instance.accountVO.Upgrade6.ToString();

        SaveUpgradeDate();
    }


    public void SaveUpgradeDate()
    {
        // Debug.Log("업그레이드 저장!!@");
        
        // 계정 저장
        AccountManager.instance.SaveAccount();
    }

}
