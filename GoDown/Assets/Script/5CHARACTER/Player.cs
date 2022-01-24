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
            Debug.Log("게이지 호출 갯수");
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
        Debug.Log("speed UP 실행");
        if (gauge < gaugelimit)
        {
            gauge += 5 * Time.deltaTime; 
            
            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05초 지남 1");
            blocks.speed = gauge;
            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05초 지남 2");
            // camera.
            float container = gauge / guide;
            camera.m_Lens.OrthographicSize = 10 + container;
            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05초 지남 3");
            
            // 배경 속도            
            backGround.BackGroundSpeed = gauge;
            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05초 지남 4");

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
            Block block = collision.gameObject.GetComponent<Block>();
            gauge = block.GetAfterGauge(gauge);

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
