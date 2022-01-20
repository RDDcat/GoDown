using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public CinemachineVirtualCamera camera;

    public GameManager gameManager;
    public Blocks blocks;

    public float gauge;
    public MoblieTouch touch;
    public BackGround2 back;
    public SpriteRenderer playerSkin;

    public float gaugelimit;
    float guide;
    bool isSpeedDelay;

    private void Start()
    {
        guide = gaugelimit / 9f;
        GameManagerMapping();
        Mapping();
    }

    private void FixedUpdate()
    {
        if (!isSpeedDelay)
        {
            StartCoroutine(SpeedUP());
        }
        
    }

    IEnumerator SpeedUP()
    {
        isSpeedDelay = true;
        if(gauge < gaugelimit)
        {
            gauge += 5 * Time.deltaTime;
            blocks.speed = gauge;
            float container = gauge / guide;
            camera.m_Lens.OrthographicSize = 10 + container;
        }        
        Debug.Log(gauge + "���� ������");
        yield return new WaitForSeconds(0.2f);
        isSpeedDelay = false;
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
