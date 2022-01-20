using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;
    public float speed;

    // private
    public bool isBlocksMove = true;
    

    private void Update()
    {
        MoveObject();
        Destroy();
    }

    private void Destroy()
    {
        if (gameObject.transform.position.y > 40)
        {
            gameObject.SetActive(false);
        }
    }

    void MoveObject()
    {
        if (isBlocksMove)
        {           
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� �ε������� ����
        if(collision.gameObject.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();

            // �÷��̾��� �ӵ��� �� hp���� ũ��
            if (p.gauge >= hp)
            {
                Debug.Log("�� �μ���");
                // ���� �μ���
                gameObject.SetActive(false);

                // ���� ȹ�� (�ϴ� +1000)
                AccountManager.instance.score += 1000;

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

    public void SetBlock(int _hp, float _speed)
    {
        hp = _hp;
        speed = _speed;
    }
}
