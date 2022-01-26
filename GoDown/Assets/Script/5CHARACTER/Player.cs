using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public new CinemachineVirtualCamera camera;

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
            // Debug.Log("������ ȣ�� ����");
            gaugeSlider.SetGaugeSlider(value);
        }
    }
    public MoblieTouch touch;
    public BackGround2 back;
    public SpriteRenderer playerSkin;

    public float gaugelimit;
    float accel;
    float guide;
    float guide2;
    bool isSpeedDelay;
    public bool isFever;

    private void Start()
    {        
        GameManagerMapping();
        Mapping();
        touch.MeltTouch();
        gaugelimit = gameManager.blockSpeedLimit;
        accel = gameManager.blockAccel;
        guide = gaugelimit / 9f;

    }

    private void FixedUpdate()
    {
        if (gameManager.onPlay)
        {
            if (!isSpeedDelay)
            {
                isSpeedDelay = true;
                if (gauge < gaugelimit)
                {
                    SetGauge();
                    BlockSpeedGauge();
                    Invoke("SetSpeedDelay", 0.08f);
                    // StartCoroutine(SpeedUP());
                    SettingCamera();
                    BackGroundSpeedGauge();
                }
                else
                {
                    Fever();
                }
            }
        }
    }        

    void SetSpeedDelay()
    {
        isSpeedDelay = false;
    }

    void SetGauge()
    {
        gauge += Time.deltaTime * accel;
    }

    void BlockSpeedGauge()
    {
        blocks.speed = gauge;
        gameManager.blockSpeed = gauge;
    }

    void BackGroundSpeedGauge()
    {
        backGround.BackGroundSpeed = gauge;
    }

    IEnumerator SpeedUP()
    {
        isSpeedDelay = true;        
        if (gauge < gaugelimit)
        {
            gauge += 20 * Time.deltaTime;
            AnimationCheck();
            yield return new WaitForSeconds(0.05f);

            SettingCamera();
            yield return new WaitForSeconds(0.05f);
            
            blocks.speed = gauge;
            yield return new WaitForSeconds(0.05f);

            SettingCamera();
            yield return new WaitForSeconds(0.05f);


            // ��� �ӵ�
            BackGroundSpeedGauge();
            yield return new WaitForSeconds(0.05f);
            SettingCamera();

        }
        else
        {
            Fever();
        }      
        
        isSpeedDelay = false;
    }

    public void AnimationCheck()
    {
        if(gauge< gaugelimit / 2)
        {
            // ���� �ִϸ��̼�

        }
        else
        {
            // ���� �ִϸ��̼�
        }
    }

    void SettingCamera()
    {
        // camera.
        float container = gauge / guide;
        camera.m_Lens.OrthographicSize = 10 + container;
    }

    public void Fever()
    {        
        if (!isFever)
        {
            StartCoroutine(DoFever());
        }
    }
    IEnumerator DoFever()
    {
        isFever = true;
        Debug.Log("�ǹ�Ÿ�� �ߵ� Check 1");
        GameObject Speed1 = EffectManager.SpawnFromPool("Speed1", playerSkin.transform.position);

        yield return new WaitForSeconds(2.5f);
        Debug.Log("�ǹ�Ÿ�� �ߵ� Check 2");

        yield return new WaitForSeconds(2.5f);
        Debug.Log("�ǹ�Ÿ�� �ߵ� Check 3");

        yield return new WaitForSeconds(2.5f);
        Debug.Log("�ǹ�Ÿ�� �ߵ� Check 4");

        yield return new WaitForSeconds(2.5f);
        Debug.Log("�ǹ�Ÿ�� ��");       
        
        gauge = gauge / 3;
        isFever = false;
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
            // back = FindObjectOfType<BackGround2>();
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
            // �� ä�� �޾ƿͼ� speed ����
            if (!isFever)
            {
                Debug.Log("�� ������Ʈ");
                Block block = collision.gameObject.GetComponent<Block>();
                gauge = block.GetAfterGauge(gauge);
            }

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
            GameObject Dead = EffectManager.SpawnFromPool("Dead", playerSkin.transform.position);
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
