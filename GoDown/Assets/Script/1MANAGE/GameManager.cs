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
        // �����
        Debug.Log("���� ��ŸƮ");

        // ����ȯ
        // �ΰ��� �� �ѱ�
        LoadInGameScene();

        // �÷��̾� ��� ����
        Invoke("Mapping", 0.1f);

        // ����ĵ���� ����
        CloseMainCanvas();

        // ��� ����
        CloseBackGround();

        // ���� ���� ����

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
        Debug.Log("���� ����");

        // ���� ���� ���� ������ ���ϱ�


        // �ְ� ���ھ� ����
        AccountManager.instance.CheckHighestScore(score);

        // ���� ����� ���� �ʱ�ȭ
        GameEndVarInit();

        // ���â �ѱ�
        OpenGameOverCanavs();

        // ���� ����


        // ���� ���� ����Ʈ


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
