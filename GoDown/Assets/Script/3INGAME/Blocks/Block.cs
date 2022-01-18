using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;
    public Blocks blocks;

    // private
    public bool isBlocksMove = true;

    private void Start()
    {
        blocks = FindObjectOfType<Blocks>();
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    void MoveObject()
    {
        if (isBlocksMove)
        {           
            transform.Translate(Vector3.up * blocks.speed * Time.deltaTime);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� �ε������� ����
        if(collision.gameObject.tag == "Player")
        {
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
