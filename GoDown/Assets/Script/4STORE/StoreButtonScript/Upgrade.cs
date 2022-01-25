using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // 게임 메니저    
    public float blockSpeed; // 시작속도
    public float blockSpeedLimit; // 최고속도 (게이지 최대치)
    public float blockAccel; // 가속도
    public float blockResistance; // 데미지 저항

    // 모바일 터치
    public float playerSpeed; // 플레이어 좌우속도
    public float multiplyGold; // 1.xx 배

    public void UpgradeBlockSpeed()
    {
        AccountManager.instance.accountVO.blockSpeed += blockSpeed;
    }

    public void UpgradeBlockSpeedLimit()
    {
        AccountManager.instance.accountVO.blockSpeedLimit += blockSpeedLimit;
    }
    public void UpgradeBlockAccel()
    {
        AccountManager.instance.accountVO.blockAccel += blockAccel;
    }
    public void UpgradeBlockResistance()
    {
        AccountManager.instance.accountVO.blockResistance += blockResistance;
    }

    public void UpgradePlayerSpeed()
    {
        AccountManager.instance.accountVO.playerSpeed += playerSpeed;
    }

    
    
    public void UpgradeMultiplyGold()
    {
        AccountManager.instance.accountVO.multiplyGold += multiplyGold;
    }


    public void SaveUpgradeDate()
    {
        Debug.Log("업그레이드 저장!!@");

    }

}
