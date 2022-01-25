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
            // Debug.Log("게이지 호출 갯수");
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
    bool isFever;

    private void Start()
    {        
        GameManagerMapping();
        Mapping();
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
        Debug.Log("블럭 속도 셋팅 횟수");
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
            SettingCamera();
            yield return new WaitForSeconds(0.05f);
            
            blocks.speed = gauge;
            yield return new WaitForSeconds(0.05f);

            SettingCamera();
            yield return new WaitForSeconds(0.05f);


            // 배경 속도            
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
        Debug.Log("피버타임 발동 Check 1");

        yield return new WaitForSeconds(2.5f);
        Debug.Log("피버타임 발동 Check 2");

        yield return new WaitForSeconds(2.5f);
        Debug.Log("피버타임 발동 Check 3");

        yield return new WaitForSeconds(2.5f);
        Debug.Log("피버타임 발동 Check 4");

        yield return new WaitForSeconds(2.5f);
        Debug.Log("피버타임 끝");       
        
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
            Debug.Log("플레이어에서 게임매니저가 맵핑이 안됨");
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
            Debug.Log("플레이어에서 맵핑이 안됨");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 블럭에 부딪혔을때 플레이어는
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            // Debug.Log("부딪혔다 플레이어가 블럭에 ");

            // 블럭 채력 받아와서 speed 감소
            if (!isFever)
            {
                Debug.Log("블럭 업데이트");
                Block block = collision.gameObject.GetComponent<Block>();
                gauge = block.GetAfterGauge(gauge);
            }
            

            // gauge 가 음수면 사망띠
            IsPlayerDead();

            // 점수 증가

        }
    }

    void IsPlayerDead()
    {
        if(gauge < 0)
        {
            // 플레이어 사망
            GameObject Dead = EffectManager.SpawnFromPool("Dead", playerSkin.transform.position);
            // 플레이어 끄기
            SetPlayerOff();

            // 플레이어 사망 이펙트


            // 플레이어 사망 사운드


            // 터치 중단
            touch.FreezeTouch();

            

            // 게임종료
            gameManager.GameEnd();

            // 디버그
            Debug.Log("플레이어의 gauge가 다 닳았습니다... (사망)");

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
