using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas MainCanvas;
    public Canvas gameOverCanvas;

    public Blocks blocks;
    public Player player;

    public long money;
    public long score;


    public void GameStart()
    {
        // �����
        Debug.Log("���� ��ŸƮ");

        // ����ȯ
        // �ΰ��� �� �ѱ�
        LoadInGameScene();

        // �÷��̾� ��� ����
        Mapping();

        // ����ĵ���� ����
        CloseMainCanvas();

        // ���� ���� ����

        //


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

    void Mapping()
    {
        blocks = FindObjectOfType<Blocks>();
        player = FindObjectOfType<Player>();
    }

    void CloseMainCanvas()
    {
        MainCanvas.enabled = false;
    }

    public void GameEnd()
    {
        // ���� ���� ���� ������ ���ϱ�

        // �ְ� ���ھ� ����
        AccountManager.instance.CheckHighestScore(score);

        // ���� ����� ���� �ʱ�ȭ
        GameEndVarInit();

        // �ΰ��� �� �ݱ�
        UnLoadInGameScene();

        // ���� ����


        // ���� ���� ����Ʈ


    }

    public void GameEndVarInit()
    {
        score = 0;
        money = 0;
    }

    void UnLoadInGameScene()
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
