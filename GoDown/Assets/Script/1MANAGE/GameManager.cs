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
    public Text goldText;
    public Text multyplyText;

    public float blockSpeed;
    public float blockSpeedLimit; // ������ ���Ѽ� ���� max 100
    public float blockAccel; // ���ӵ� ���� + 0.001f ��
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
        // �����
        Debug.Log("���� ��ŸƮ");

        onPlay = true;

        // ��ġ ��������
        InitAccountData();

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
        Debug.Log("���� ����");
        // ���� ������Ʈ ���� �ߴ�
        spawnManager.StopSpawn();

        // ��� �ؽ�Ʈ ����
        SetResultText();

        // �÷��̾� ���� �ߴ�
        onPlay = false;

        // ���� ���� ���� ������ ���ϱ�
        AccountManager.instance.SetGold();

        // �ְ� ���ھ� ����
        // AccountManager.instance.CheckHighestScore();

        // ���â 
        Invoke("GameOverCanvas", 0.45f); // ���ӵ��� ���缭 �ö���� ����

        // ���� ����


        // ���� ���� ����Ʈ


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

        // ���� ���ھ� �ʱ�ȭ
        AccountManager.instance.InitVariables();

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
