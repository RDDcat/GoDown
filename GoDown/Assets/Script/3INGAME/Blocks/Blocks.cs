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
            Debug.Log("���ǵ� ��û");
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
            // Debug.Log("�� ���ǵ� ���� ��ȭ ��ɾ� ���� ī����");
            if (block[i].isActiveAndEnabled)
            {
                block[i].SetSpeed(__speed);
            }
            
        }

    }
    

    public void MappingAllBlocks()
    {
        // Debug.Log("��� ����");

        block = FindObjectsOfType<Block>();

        // ��� ��� �Ϸ� �� �������
        objectManager.AllFade();
    }

    public void FreezeBlocks()
    {
        Debug.Log("FreezeBlocks ����");
        speed = 0;
    }
}
