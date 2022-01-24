using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public CinemachineVirtualCamera camera;

    public GameManager gameManager;
    public Blocks blocks;
    public BackGround backGround;
    public Gauge gaugeSlider;

    public float _gauge;
    public float gauge
    {
        get
        {
            return _gauge;
        }
        set
        {
            _gauge = value;
            Debug.Log("������ ȣ�� ����");
            gaugeSlider.SetGaugeSlider(value);
        }
    }
    public MoblieTouch touch;
    public BackGround2 back;
    public SpriteRenderer playerSkin;

    public float gaugelimit;
    float guide;
    float guide2;
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
        Debug.Log("speed UP ����");
        if (gauge < gaugelimit)
        {
            gauge += 5 * Time.deltaTime; 
            
            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05�� ���� 1");
            blocks.speed = gauge;
            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05�� ���� 2");
            // camera.
            float container = gauge / guide;
            camera.m_Lens.OrthographicSize = 10 + container;
            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05�� ���� 3");
            
            // ��� �ӵ�            
            backGround.BackGroundSpeed = gauge;
            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05�� ���� 4");

        }        
        
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
            backGround = FindObjectOfType<BackGround>();
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
