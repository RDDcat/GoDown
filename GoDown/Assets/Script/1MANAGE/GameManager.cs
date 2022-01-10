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
        // �����
        Debug.Log("���� ��ŸƮ");

        // ����ȯ
        // �ΰ��� �� �ѱ�
        LoadInGameScene();

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

        // ���� ����


        // ���� ���� ����Ʈ


    }

    public void GameEndVarInit()
    {
        score = 0;
        money = 0;
    }
}
