using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // �ٸ���
    public SpawnManager spawnManager;
    public ObjectManager objectManager;

    public Blocks blocks;
    public Player player;

    // ��
    public Canvas MainCanvas;
    public Canvas gameOverCanvas;
    public GameObject backGround;

    public RectTransform GameOver;

    public Text scoreText;
    
    public long money;
    public long score;

    public float blockSpeed;
    public int blockHP;

    private void Start()
    {
        objectManager = FindObjectOfType<ObjectManager>();
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

        // �÷��̾� �ѱ�
        player.SetPlayerOn();

        // ���� ������Ʈ ���� ����
        // spawnManager.StartSpawn();

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
        Debug.Log("���� ����");
        // ���� ������Ʈ ���� �ߴ�
        spawnManager.StopSpawn();

        // ��� �ؽ�Ʈ ����
        SetResultText();


        // ���� ���� ���� ������ ���ϱ�


        // �ְ� ���ھ� ����
        AccountManager.instance.CheckHighestScore(score);

        // ���â 
        Invoke("GameOverCanvas", 0.45f); // ���ӵ��� ���缭 �ö���� ����

        // ���� ����


        // ���� ���� ����Ʈ


    }

    public void SetResultText()
    {
        scoreText.text = AccountManager.instance.score.ToString();
    }

    public void GameOverCanvas()
    {
        GameOver.DOAnchorPos(Vector2.zero, 1f);
    }

    public void GameEndVarInit()
    {
        score = 0;
        money = 0;

        // ���� ���ھ� �ʱ�ȭ
        AccountManager.instance.score = 0;

        // ���â �ű��
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
