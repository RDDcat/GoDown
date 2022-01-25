using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // 다른씬
    public SpawnManager spawnManager;
    public ObjectManager objectManager;

    public Blocks blocks;
    public Player player;

    // 씬
    public Canvas MainCanvas;
    public Canvas gameOverCanvas;
    public GameObject backGround;

    public RectTransform GameOver;

    public Text scoreText;
    public Text goldText;
    public Text multyplyText;

    public float blockSpeed;
    public float blockSpeedLimit; // 게이지 상한선 업글 max 100
    public float blockAccel; // 가속도 업글 + 0.001f 씩
    public int blockHP;
    public int blockScore;
    public float blockResistance;


    public bool onPlay;

    private void Start()
    {
        objectManager = FindObjectOfType<ObjectManager>();
        InitAccountData();
    }

    public void GameStart()
    {
        // 디버그
        Debug.Log("게임 스타트");

        onPlay = true;

        // 수치 가져오기
        InitAccountData();

        // 씬전환
        // 인게임 씬 켜기
        LoadInGameScene();

        // 플레이어 블록 맵핑
        Invoke("Mapping", 0.1f);

        // 메인캔버스 끄기
        CloseMainCanvas();

        // 배경 끄기
        CloseBackGround();

        
        // 게임 시작 사운드

        // 플레이어 켜기
        player.SetPlayerOn();

        // 게임 오브젝트 스폰 시작
        // spawnManager.StartSpawn();

    }

    void InitAccountData()
    {
        blockSpeed = AccountManager.instance.accountVO.blockSpeed;
        blockSpeedLimit = AccountManager.instance.accountVO.blockSpeedLimit;
        blockAccel = AccountManager.instance.accountVO.blockAccel;
        blockResistance = AccountManager.instance.accountVO.blockResistance;
    }

    void CloseBackGround()
    {
        backGround.SetActive(false);
    }

    void OpenBackGround()
    {
        backGround.SetActive(true);
    }

    void LoadInGameScene()
    {
        if (SceneManager.GetSceneByName("3INGAME").isLoaded == false)
        {
            SceneManager.LoadSceneAsync("3INGAME", LoadSceneMode.Additive);
        }
        if (SceneManager.GetSceneByName("5CHARACTER").isLoaded == false)
        {
            SceneManager.LoadSceneAsync("5CHARACTER", LoadSceneMode.Additive);
        }
    }

    public void Mapping()
    {
        if (blocks == null)
        {
            blocks = FindObjectOfType<Blocks>();
        }
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        if(spawnManager == null)
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }
    }

    void CloseMainCanvas()
    {
        MainCanvas.enabled = false;
    }

    public void OpenMainCanvas()
    {
        MainCanvas.enabled = true;
    }    

    public void GameEnd()
    {
        Debug.Log("게임 엔드");
        // 게임 오브젝트 스폰 중단
        spawnManager.StopSpawn();

        // 결과 텍스트 지정
        SetResultText();

        // 플레이어 가속 중단
        onPlay = false;

        // 게임 종료 보상 계정에 더하기
        AccountManager.instance.SetGold();

        // 최고 스코어 저장
        // AccountManager.instance.CheckHighestScore();

        // 결과창 
        Invoke("GameOverCanvas", 0.45f); // 배경속도에 맞춰서 올라오면 좋음

        // 계정 저장


        // 게임 종료 이펙트


    }

    public void SetResultText()
    {
        scoreText.text = AccountManager.instance.score.ToString();
        goldText.text = AccountManager.instance.GetGold().ToString();
        multyplyText.text = "x" + AccountManager.instance.multiplyGold.ToString();
    }

    public void GameOverCanvas()
    {
        GameOver.DOAnchorPos(Vector2.zero, 1f);
    }

    public void GameEndVarInit()
    {
        onPlay = false;

        // 계정 스코어 초기화
        AccountManager.instance.InitVariables();

        // 결과창 옮기기
        GameOver.position = new Vector2(GameOver.position.x, -2400);
    }

    public void GameOverButton()
    {
        UnLoadInGameScene();
        OpenMainCanvas();
        OpenBackGround();
        objectManager.OffObjects();
        GameEndVarInit();
    }

    public void UnLoadInGameScene()
    {
        if (SceneManager.GetSceneByName("3INGAME").isLoaded == true)
        {
            SceneManager.UnloadSceneAsync("3INGAME");
        }
        if (SceneManager.GetSceneByName("5CHARACTER").isLoaded == true)
        {
            SceneManager.UnloadSceneAsync("5CHARACTER");
        }        
    }
}
