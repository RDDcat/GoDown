using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� �ε������� ����
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("��� ��ġ");
            Player p = collision.gameObject.GetComponent<Player>();

            // �÷��̾��� �ӵ��� �� hp���� ũ��
            if (p.gauge > hp)
            {
                // ���� �μ���
                
            }
            else
            {
                // ���� �Ⱥμ���

            }

        }
    }

    public float GetAfterGauge(float gauge)
    {
        return gauge - hp;
    }
}
