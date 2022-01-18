using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas MainCanvas;
    public Canvas gameOverCanvas;
    public GameObject backGround;
    
    public Blocks blocks;
    public Player player;

    public long money;
    public long score;

    private void Start()
    {

    }

    public void GameStart()
    {
        // 디버그
        Debug.Log("게임 스타트");

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

        //


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
    }

    void CloseMainCanvas()
    {
        MainCanvas.enabled = false;
    }

    public void OpenMainCanvas()
    {
        MainCanvas.enabled = true;
    }
    public void CloseGameOverCanavs()
    {
        gameOverCanvas.enabled = false;
    }

    public void OpenGameOverCanavs()
    {
        gameOverCanvas.enabled = true;
    }

    public void GameEnd()
    {
        Debug.Log("게임 엔드");

        // 게임 종료 보상 계정에 더하기


        // 최고 스코어 저장
        AccountManager.instance.CheckHighestScore(score);

        // 게임 종료시 변수 초기화
        GameEndVarInit();

        // 결과창 켜기
        OpenGameOverCanavs();

        // 계정 저장


        // 게임 종료 이펙트


    }

    public void GameEndVarInit()
    {
        score = 0;
        money = 0;
    }

    public void GameOverButton()
    {
        UnLoadInGameScene();
        OpenMainCanvas();
        CloseGameOverCanavs();
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
