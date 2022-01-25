using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public ObjectManager objectManager;

    public Block[] block;


    float _speed;
    public float speed
    {
        get
        {
            Debug.Log("스피드 요청");
            return _speed;
        }
        set
        {
            _speed = value;
            SetSpeed(_speed);
        }
    }

    public void DebugSpeed()
    {
        speed += 10;
    }

    public void SetSpeed(float __speed)
    {
        for(int i=0;i < block.Length; i++)
        {
            // Debug.Log("블럭 스피드 설정 변화 명령어 갯수 카운팅");
            if (block[i].isActiveAndEnabled)
            {
                block[i].SetSpeed(__speed);
            }
            
        }

    }
    

    public void MappingAllBlocks()
    {
        // Debug.Log("블록 맵핑");

        block = FindObjectsOfType<Block>();

        // 블록 등록 완료 후 사라지게
        objectManager.AllFade();
    }

    public void FreezeBlocks()
    {
        Debug.Log("FreezeBlocks 얼음");
        speed = 0;
    }
}
