using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    // ���� �޴���    
    public float blockAccel; // ���ӵ�    
    public float blockSpeedLimit; // �ְ�ӵ� (������ �ִ�ġ)
    public float blockSpeed; // ���ۼӵ�
    public float blockResistance; // ������ ����

    // ����� ��ġ
    public float playerSpeed; // �÷��̾� �¿�ӵ�
    public float multiplyGold; // 1.xx ��


    // ��� �ؽ�Ʈ �ޱ�
    public TextMeshProUGUI blockAccelText;
    public TextMeshProUGUI blockSpeedLimitText;
    public TextMeshProUGUI blockSpeedText;    
    public TextMeshProUGUI playerSpeedText;
    public TextMeshProUGUI blockResistanceText;
    public TextMeshProUGUI multiplyGoldText;

    // ���� �ؽ�Ʈ �ޱ�
    public TextMeshProUGUI blockAccelLevelText;
    public TextMeshProUGUI blockSpeedLimitLevelText;
    public TextMeshProUGUI blockSpeedLevelText;
    public TextMeshProUGUI playerSpeedLevelText;
    public TextMeshProUGUI blockResistanceLevelText;
    public TextMeshProUGUI multiplyGoldLevelText;

    private void Start()
    {
        // �ؽ�Ʈ �ʱ�ȭ
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
        // ���� ���� ���ٸ� ��ŵ
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade1 * 10)
        {            
            return;
        }
        //ȿ����
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // ���Ҹ�
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade1 * 10;

        // ���׷��̵� ����
        AccountManager.instance.accountVO.Upgrade1 += 1;

        // �����Ҹ�ġ �ؽ�Ʈ ������Ʈ
        blockAccelText.text = ((AccountManager.instance.accountVO.Upgrade1 + 1) * 10).ToString();

        // ��ȭ
        AccountManager.instance.accountVO.blockSpeed += blockSpeed;

        blockAccelLevelText.text = AccountManager.instance.accountVO.Upgrade1.ToString();

        SaveUpgradeDate();
    }

    public void UpgradeBlockSpeedLimit()
    {
        // ���� ���� ���ٸ� ��ŵ
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade2 * 10)
        {
            return;
        }
        //ȿ����
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // ���Ҹ�
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade2 * 10;

        // ���׷��̵� ����
        AccountManager.instance.accountVO.Upgrade2 += 1;

        // �����Ҹ�ġ �ؽ�Ʈ ������Ʈ
        blockSpeedLimitText.text = ((AccountManager.instance.accountVO.Upgrade2 + 1) * 10).ToString();

        AccountManager.instance.accountVO.blockSpeedLimit += blockSpeedLimit;

        blockSpeedLimitLevelText.text = AccountManager.instance.accountVO.Upgrade2.ToString();

        SaveUpgradeDate();
    }

    public void UpgradeBlockSpeed()
    {
        // ���� ���� ���ٸ� ��ŵ
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade3 * 10)
        {            
            return;
        }
        //ȿ����
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // ���Ҹ�
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade3 * 10;

        // ���׷��̵� ����
        AccountManager.instance.accountVO.Upgrade3 += 1;

        // �����Ҹ�ġ �ؽ�Ʈ ������Ʈ
        blockSpeedText.text = ((AccountManager.instance.accountVO.Upgrade3 + 1) * 10).ToString();

        // ��ȭ
        AccountManager.instance.accountVO.blockSpeed += blockSpeed;

        blockSpeedLevelText.text = AccountManager.instance.accountVO.Upgrade3.ToString();

        SaveUpgradeDate();
    }

    
    public void UpgradePlayerSpeed()
    {
        // ���� ���� ���ٸ� ��ŵ
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade4 * 10)
        {
            return;
        }
        //ȿ����
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // ���Ҹ�
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade4 * 10;

        // ���׷��̵� ����
        AccountManager.instance.accountVO.Upgrade4 += 1;

        // �����Ҹ�ġ �ؽ�Ʈ ������Ʈ
        playerSpeedText.text = ((AccountManager.instance.accountVO.Upgrade4 + 1) * 10).ToString();

        AccountManager.instance.accountVO.playerSpeed += playerSpeed;

        playerSpeedLevelText.text = AccountManager.instance.accountVO.Upgrade4.ToString();

        SaveUpgradeDate();
    }


    public void UpgradeBlockResistance()
    {
        // ���� ���� ���ٸ� ��ŵ
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade5 * 10)
        {
            return;
        }
        //ȿ����
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // ���Ҹ�
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade5 * 10;

        // ���׷��̵� ����
        AccountManager.instance.accountVO.Upgrade5 += 1;

        // �����Ҹ�ġ �ؽ�Ʈ ������Ʈ
        blockResistanceText.text = ((AccountManager.instance.accountVO.Upgrade5 + 1) * 10).ToString();

        AccountManager.instance.accountVO.blockResistance += blockResistance;

        blockResistanceLevelText.text = AccountManager.instance.accountVO.Upgrade5.ToString();

        SaveUpgradeDate();
    }


    public void UpgradeMultiplyGold()
    {
        // ���� ���� ���ٸ� ��ŵ
        if (AccountManager.instance.accountGold < AccountManager.instance.accountVO.Upgrade6 * 10)
        {
            return;
        }
        //ȿ����
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

        // ���Ҹ�
        AccountManager.instance.accountGold -= AccountManager.instance.accountVO.Upgrade6 * 10;

        // ���׷��̵� ����
        AccountManager.instance.accountVO.Upgrade6 += 1;

        // �����Ҹ�ġ �ؽ�Ʈ ������Ʈ
        multiplyGoldText.text = ((AccountManager.instance.accountVO.Upgrade6 + 1) * 10).ToString();

        AccountManager.instance.accountVO.multiplyGold += multiplyGold;

        multiplyGoldLevelText.text = AccountManager.instance.accountVO.Upgrade6.ToString();

        SaveUpgradeDate();
    }


    public void SaveUpgradeDate()
    {
        // Debug.Log("���׷��̵� ����!!@");
        
        // ���� ����
        AccountManager.instance.SaveAccount();
    }

}
