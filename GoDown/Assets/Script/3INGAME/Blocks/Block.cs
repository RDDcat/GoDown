using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;
    public float speed;
<<<<<<< HEAD
    public int score;
    public float resistance;
=======
    public int blockLv;
>>>>>>> [UPDATE] 이펙트 매니저, 이펙트 프리펩 업데이트, 앱이미지 추가


    // private
    public bool isBlocksMove = true;

    private void Start()
    {
        // rigid = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        MoveObject();
        Destroy();
    }

    public void SetSpeed(float _speed)
    {
        // Debug.Log("������ �ӵ���ȭ ����");
        speed = _speed;
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
        if (gameObject.activeSelf)
        {
            if (isBlocksMove)
            {
                // rigid.AddForce(Vector3.up * speed );
                transform.Translate(0, speed * 0.008f, 0);
                //* Time.deltaTime
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ������ �ε������� ������
        if(collision.gameObject.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();

            // �÷��̾��� �ӵ��� ���� hp���� ũ��
            if (p.gauge >= hp)
            {
                Debug.Log("���� �μ���");
                // ������ �μ���
                gameObject.SetActive(false);
                // ���� �ı� ����Ʈ
                switch (blockLv)
                {
                    case 0 :
                        GameObject Break1 = EffectManager.SpawnFromPool("Break1", rigid.position);
                        break;
                    case 1:
                        GameObject Break2 = EffectManager.SpawnFromPool("Break2", rigid.position);
                        break;
                    case 2:
                        GameObject Break3 = EffectManager.SpawnFromPool("Break3", rigid.position);
                        break;
                }
                

                // ���� ȹ�� (�ϴ� +1000)
                AccountManager.instance.score += score;


            }
            else
            {
                // ������ �Ⱥμ���
                gameObject.SetActive(false);
            }

        }
    }

    public float GetAfterGauge(float gauge)
    {
        float damage = hp * resistance;
        return gauge - damage;
    }

    public void SetBlock(int _hp, float _speed, int _score, float _resistance)
    {
        hp = _hp;
        speed = _speed;
        score = _score;
        resistance = _resistance / (_resistance + 2500);

    }
}
