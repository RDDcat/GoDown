using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float gauge;
    public MoblieTouch touch;
    public Blocks blocks;
    public BackGround2 back;
    public SpriteRenderer playerSkin;


    private void Start()
    {
        GameManagerMapping();
        Mapping();
    }

    void GameManagerMapping()
    {
        try
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.Mapping();
        }
        catch
        {
            Debug.Log("�÷��̾�� ���ӸŴ����� ������ �ȵ�");
        }
    }

    public void Mapping()
    {
        try
        {
            blocks = FindObjectOfType<Blocks>();
            back = FindObjectOfType<BackGround2>();
        }
        catch
        {
            Debug.Log("�÷��̾�� ������ �ȵ�");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� �ε������� �÷��̾��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            // Debug.Log("�ε����� �÷��̾ ���� ");

            // �� ä�� �޾ƿͼ� speed ����
            Block block = collision.gameObject.GetComponent<Block>();
            gauge = block.GetAfterGauge(gauge);

            // gauge �� ������ �����
            IsPlayerDead();

            // ���� ����

        }
    }

    void IsPlayerDead()
    {
        if(gauge < 0)
        {
            // �÷��̾� ���            
            // �÷��̾� ����
            SetPlayerOff();

            // �÷��̾� ��� ����Ʈ


            // �÷��̾� ��� ����


            // ��ġ �ߴ�
            touch.FreezeTouch();

            

            // ��������
            gameManager.GameEnd();

            // �����
            Debug.Log("�÷��̾��� gauge�� �� ��ҽ��ϴ�... (���)");

        }
    }

    public void SetPlayerOn()
    {
        if (playerSkin == null)
            return;
        playerSkin.enabled = true;
    }
    public void SetPlayerOff()
    {
        playerSkin.enabled = false;
    }
}
