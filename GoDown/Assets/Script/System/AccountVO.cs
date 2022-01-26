using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountVO
{
    public int level;
    public long gold;
    public long highestScore;

    public float multiplyGold; // 1.xx ��

    // ���� �޴���    
    public float blockSpeed; // ���ۼӵ�
    public float blockSpeedLimit; // �ְ�ӵ� (������ �ִ�ġ)
    public float blockAccel; // ���ӵ�
    public float blockResistance; // ������ ����
        
    // ����� ��ġ
    public float playerSpeed; // �÷��̾� �¿�ӵ�


    // ���׷��̵� ������
    public int Upgrade1;
    public int Upgrade2;
    public int Upgrade3;
    public int Upgrade4;
    public int Upgrade5;
    public int Upgrade6;
}
