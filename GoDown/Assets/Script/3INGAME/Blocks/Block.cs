using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float hp;
    public float speed;
    public int score;
    public float resistance;

    public int blockLv;


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
        // Debug.Log("���� �ӵ���ȭ ����");
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
        // �÷��̾ ���� �ε������� ����
        if(collision.gameObject.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();

            // �÷��̾��� �ӵ��� �� hp���� ũ��
            if (p.gauge >= 0)
            {                
                // ���� �μ���
                gameObject.SetActive(false);
                // �� �ı� ����Ʈ
                PlayEffect();


                // ���� ȹ�� (�ϴ� +1000)
                AccountManager.instance.score += score;


            }
            else
            {
                // ���� �Ⱥμ���
                gameObject.SetActive(false);
                PlayEffect();
            }

        }
    }

    public void PlayEffect()
    {
        switch (blockLv)
        {
            case -1:
                EffectManager.SpawnFromPool("Break01", gameObject.transform.position);
                break;
            case 1:
                EffectManager.SpawnFromPool("Break1", gameObject.transform.position);
                break;
            case 2:
                Debug.Log("����Ʈ 2�� �÷���");
                EffectManager.SpawnFromPool("Break2", gameObject.transform.position);
                break;
            case 3:
                EffectManager.SpawnFromPool("Break3", gameObject.transform.position);
                break;
        }
    }

    public float GetAfterGauge(float gauge)
    {
        float damage = hp * (1 - resistance);
        return gauge - damage;
    }

    public void SetBlock(float _hp, float _speed, int _score, float _resistance)
    {
        hp = _hp;
        speed = _speed;
        score = _score;
        resistance = _resistance / (_resistance + 2500);

    }
}
