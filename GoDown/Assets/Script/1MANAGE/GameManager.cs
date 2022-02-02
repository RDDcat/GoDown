using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

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
    public TextMeshProUGUI rewardGoldText;

    public float blockSpeed;
    public float blockSpeedLimit; // 게이지 상한선 업글 max 100
    public float blockAccel; // 가속도 업글 + 0.001f 씩
    public float blockHP;
    public int blockScore;
    public float blockResistance;


    public bool onPlay;
    public int level;

    private void Start()
    {
        objectManager = FindObjectOfType<ObjectManager>();
        InitAccountData();
    }

    public void GameStart()
    {
        // 디버그
        // Debug.Log("게임 스타트");

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
        
        // 어카운트 매니저 점수 캔버스 켜기
        AccountManager.instance.OnGameCanvas();

        // 배경 끄기
        CloseBackGround();                

        // 게임 시작 사운드
        StartCoroutine(IngameSound());

        // 점수 증가 & 블럭 강화
        StartCoroutine(AutoAddScore());
        StartCoroutine(AutoAddLevel());
    }

    IEnumerator IngameSound()
    {
        SoundManager.instance.bgmPlay(SoundManager.Bgm.Next);
        yield return new WaitForSeconds(1.5f);
        SoundManager.instance.bgmPlay(SoundManager.Bgm.Ingame);
        yield break;
    }

    IEnumerator AutoAddLevel()
    {
        int delayTime = 18;
        while (true)
        {
            if (onPlay)
            {
                blockHP += 0.2f;
                blockScore += 10;
                level += 1;
                int delaylevel = level % delayTime;
                MoveMiniMap(delayTime, delaylevel);
                if (delaylevel == 0) // 28렙 마다 한번씩
                {
                    spawnManager.StopSpawn();
                    yield return new WaitForSeconds(spawnManager.SpawnLayer(level));
                    ResetMiniMap();                    
                }
                yield return new WaitForSeconds(2f);
            }
            else
            {
                yield break;
            }
        }
    }

    void MoveMiniMap(int _step, int _delaylevel)
    {
        if (player != null)
        {
            //Debug.Log("엥");
            // 슬라임이 일정 거리만큼 내려감
            player.MoveMiniMap(_step, _delaylevel);
        }
        
        
    }

    void ResetMiniMap()
    {
        if (player != null)
        {
            //Debug.Log("엥엥엥엥");
            // 슬라임이 다시 올라옴
            player.ResetMiniMap();
        }
    }


    IEnumerator AutoAddScore()
    {
        while (true)
        {
            if (onPlay)
            {
                AccountManager.instance.score += 10;
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                yield break;
            }
        }        
    }

    void InitAccountData()
    {
        try
        {
            blockSpeed = AccountManager.instance.accountVO.blockSpeed;
            blockSpeedLimit = AccountManager.instance.accountVO.blockSpeedLimit;
            blockAccel = AccountManager.instance.accountVO.blockAccel;
            blockResistance = AccountManager.instance.accountVO.blockResistance;
        }
        catch
        {
            Debug.LogErrorFormat("게임메니저 계정데이터 불러오기 에러");
            Invoke("InitAccountData", 0.1f);
        }
        
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

            // 미니맵 초기화
            ResetMiniMap();
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
        // 디버그
        // Debug.Log("게임 엔드");

        if (!onPlay)
        {
            return;
        }

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
        AccountManager.instance.SaveAccount();

    }

    public void SetResultText()
    {
        scoreText.text = AccountManager.instance.score.ToString();
        goldText.text = AccountManager.instance.GetGold().ToString();
        multyplyText.text = "x" + AccountManager.instance.accountVO.multiplyGold.ToString();
        long rewardGold = (long)(AccountManager.instance.GetGold() * AccountManager.instance.accountVO.multiplyGold);
        rewardGoldText.text = rewardGold.ToString();
    }

    public void GameOverCanvas()
    {
        GameOver.DOAnchorPos(Vector2.zero, 1f);
    }

    public void GameEndVarInit()
    {
        onPlay = false;
        level = 0;
        blockHP = 1;
        blockScore = 100;


        // 계정 스코어 초기화
        AccountManager.instance.InitVariables();

        // 결과창 옮기기
        GameOver.position = new Vector2(GameOver.position.x, -2400);

        // 배경음 전환
        SoundManager.instance.bgmPlay(SoundManager.Bgm.Main);
    }

    public void GameOverButton()
    {
        UnLoadInGameScene();
        OpenMainCanvas();
        OpenBackGround();
        objectManager.OffObjects();
        GameEndVarInit();
        
        // 어카운트 매니저 메인 켜기
        AccountManager.instance.OnMainCanvas();
        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
    }

    public void GameEndWhilePlay()
    {
        if (!onPlay)
        {
            return;
        }

        // 게임 오브젝트 스폰 중단
        spawnManager.StopSpawn();

        // 플레이어 가속 중단
        onPlay = false;

        // 게임 종료 보상 계정에 더하기
        AccountManager.instance.SetGold();

        // 계정 저장
        AccountManager.instance.SaveAccount();

        GameOverButton();
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
