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
    public GameObject slimeHandler;
    public GameObject[] handlerpos;

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
            gaugeSlider.UpdateGaugeSlider(value);
        }
    }
    public MoblieTouch touch;
    public BackGround2 back;
    public SpriteRenderer playerSkin;

    public PlayerAni playerAni;
    public FeverEffect feverEffect;
    public ParticleSystem fever1;

    public float gaugelimit;
    float accel;
    float guide;
    float guide2;
    bool isSpeedDelay;
    public bool isFever;

    private void Awake()
    {
        GameManagerMapping();
        Mapping();
    }

    private void Start()
    {
        touch.MeltTouch();
        guide = gaugelimit / 8f;
        gaugelimit = gameManager.blockSpeedLimit;
        accel = gameManager.blockAccel;        
        gaugeSlider.SetSlider();
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
                    playerAni.HighSpeedAni();
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
    void SettingCamera()
    {
        // camera.
        float container = gauge / guide;
        camera.m_Lens.OrthographicSize = 8 + container;
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

        gauge += 2;
        camera.m_Lens.OrthographicSize = 19;

        try
        {
            fever1.Play();
            StartCoroutine(FeverHighLight());
        }
        catch
        {
            Debug.Log("�ǹ� ����Ʈ �÷��� ����");
        }

        gaugeSlider.OpenFeverSlider();
        yield return new WaitForSeconds(1f); // 1
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 2
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 3
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 4
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 5
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 6
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 7
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 8
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 9
        gaugeSlider.SetFeverSlider(0.1f);
        yield return new WaitForSeconds(1f); // 10

        gaugeSlider.CloseFeverSlider();
        Debug.Log("�ǹ�Ÿ�� ��");
        
        gauge = gauge / 3;
        isFever = false;
        isSpeedDelay = false;

        fever1.Stop();
    }

    IEnumerator FeverHighLight()
    {
        feverEffect.OnOff_Fever();
        while (isFever)
        {
            feverEffect.RandomShake();
            yield return new WaitForSeconds(0.1f);
        }
        feverEffect.OnOff_Fever();
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
            playerAni = FindObjectOfType<PlayerAni>();
            feverEffect = FindObjectOfType<FeverEffect>();
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
            //ȿ���� 
            SoundManager.instance.sfxPlay(SoundManager.Sfx.Break);
            // �� ä�� �޾ƿͼ� speed ����
            if (!isFever)
            {
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
        if(gauge < 2.5f)
        {
            // �÷��̾� ���
            
            // �÷��̾� ����
            SetPlayerOff();

            // �÷��̾� ��� ����Ʈ
            EffectManager.SpawnFromPool("Dead", playerSkin.transform.position);

            // �÷��̾� ��� ����
            SoundManager.instance.sfxPlay(SoundManager.Sfx.Dead);

            // ��ġ �ߴ�
            touch.FreezeTouch();

            

            // ��������
            gameManager.GameEnd();

            
        }
    }

    public void SetPlayerOn()
    {
        if (playerSkin == null)
            return;
        playerSkin.enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
    public void SetPlayerOff()
    {
        playerSkin.enabled = false; 
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    float y;
    public void MoveMiniMap(int _step, int _delaylevel)
    {
        
        if(y == 0)
        {
            y = (handlerpos[0].transform.position.y - handlerpos[1].transform.position.y) / _step;
        }
        
        //Debug.Log("�������� " + y);
        slimeHandler.transform.position = new Vector2(slimeHandler.transform.position.x, slimeHandler.transform.position.y - y);
    }

    public void ResetMiniMap()
    {
        //Debug.Log("�ʱ�ȭ~");
        slimeHandler.transform.position = handlerpos[0].transform.position;
    }
}
