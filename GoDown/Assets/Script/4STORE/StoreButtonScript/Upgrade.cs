using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // ���� �޴���    
    public float blockSpeed; // ���ۼӵ�
    public float blockSpeedLimit; // �ְ�ӵ� (������ �ִ�ġ)
    public float blockAccel; // ���ӵ�
    public float blockResistance; // ������ ����

    // ����� ��ġ
    public float playerSpeed; // �÷��̾� �¿�ӵ�
    public float multiplyGold; // 1.xx ��

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
        Debug.Log("���׷��̵� ����!!@");

    }

}
