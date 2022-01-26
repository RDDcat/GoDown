using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountVO
{
    public int level;
    public long gold;
    public long highestScore;

    public float multiplyGold; // 1.xx 배

    // 게임 메니저    
    public float blockSpeed; // 시작속도
    public float blockSpeedLimit; // 최고속도 (게이지 최대치)
    public float blockAccel; // 가속도
    public float blockResistance; // 데미지 저항
        
    // 모바일 터치
    public float playerSpeed; // 플레이어 좌우속도


    // 업그레이드 데이터
    public int Upgrade1;
    public int Upgrade2;
    public int Upgrade3;
    public int Upgrade4;
    public int Upgrade5;
    public int Upgrade6;
}
