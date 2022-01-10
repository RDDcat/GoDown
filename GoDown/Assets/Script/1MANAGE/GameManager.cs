using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas MainCanvas;
    public Canvas gameOverCanvas;

    public long money;
    public long score;


    public void GameStart()
    {
        // 디버그
        Debug.Log("게임 스타트");

        // 씬전환
        // 인게임 씬 켜기
        LoadInGameScene();

        // 메인캔버스 끄기
        CloseMainCanvas();

        // 게임 시작 사운드

        //


    }

    void LoadInGameScene()
    {
        if (SceneManager.GetSceneByName("3INGAME").isLoaded == false)
        {
            SceneManager.LoadSceneAsync("3INGAME", LoadSceneMode.Additive);
        }
    }

    void CloseMainCanvas()
    {
        MainCanvas.enabled = false;
    }

    public void GameEnd()
    {
        // 게임 종료 보상 계정에 더하기

        // 최고 스코어 저장
        AccountManager.instance.CheckHighestScore(score);

        // 게임 종료시 변수 초기화
        GameEndVarInit();

        // 계정 저장


        // 게임 종료 이펙트


    }

    public void GameEndVarInit()
    {
        score = 0;
        money = 0;
    }
}
