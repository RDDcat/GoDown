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
            // Debug.Log("게이지 호출 갯수");
            gaugeSlider.SetGaugeSlider(value);
        }
    }
    public MoblieTouch touch;
    public BackGround2 back;
    public SpriteRenderer playerSkin;

    public PlayerAni playerAni;
    public ParticleSystem fever1;

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

        playerAni = FindObjectOfType<PlayerAni>();
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
        
        try
        {
            fever1.Play();
        }
        catch
        {
            Debug.Log("피버 이펙트 플레이 오류");
        }
        

        yield return new WaitForSeconds(2.5f);
        
        yield return new WaitForSeconds(2.5f);
        
        yield return new WaitForSeconds(2.5f);
        
        yield return new WaitForSeconds(2.5f);
        Debug.Log("피버타임 끝");
        
        gauge = gauge / 3;
        isFever = false;
        isSpeedDelay = false;

        fever1.Stop();
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
            // back = FindObjectOfType<BackGround2>();
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
            //효과음 
            SoundManager.instance.sfxPlay(SoundManager.Sfx.Break);
            // 블럭 채력 받아와서 speed 감소
            if (!isFever)
            {
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
        if(gauge < 1)
        {
            // 플레이어 사망
            
            // 플레이어 끄기
            SetPlayerOff();

            // 플레이어 사망 이펙트
            EffectManager.SpawnFromPool("Dead", playerSkin.transform.position);

            // 플레이어 사망 사운드
            SoundManager.instance.sfxPlay(SoundManager.Sfx.Dead);

            // 터치 중단
            touch.FreezeTouch();

            

            // 게임종료
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
}
