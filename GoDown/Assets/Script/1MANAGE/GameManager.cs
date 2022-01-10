using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    


    public void GameStart()
    {
        // 디버그
        Debug.Log("게임 스타트");

        // 씬전환
        if(SceneManager.GetSceneByName("3INGAME").isLoaded == false)
        {
            SceneManager.LoadSceneAsync("3INGAME", LoadSceneMode.Additive);
        }
        
        

        // 게임 시작 사운드

        //


    }

    public void GameEnd()
    {
        // 게임 종료 보상 계정에 더하기

        // 계정 저장

        // 게임 종료 이펙트


    }
}
