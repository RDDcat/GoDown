using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

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
    public TextMeshProUGUI rewardGoldText;

    public float blockSpeed;
    public float blockSpeedLimit; // ������ ���Ѽ� ���� max 100
    public float blockAccel; // ���ӵ� ���� + 0.001f ��
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
        // �����
        // Debug.Log("���� ��ŸƮ");

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
        
        // ��ī��Ʈ �Ŵ��� ���� ĵ���� �ѱ�
        AccountManager.instance.OnGameCanvas();

        // ��� ����
        CloseBackGround();                

        // ���� ���� ����
        StartCoroutine(IngameSound());

        // ���� ���� & �� ��ȭ
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
                if (delaylevel == 0) // 28�� ���� �ѹ���
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
            //Debug.Log("��");
            // �������� ���� �Ÿ���ŭ ������
            player.MoveMiniMap(_step, _delaylevel);
        }
        
        
    }

    void ResetMiniMap()
    {
        if (player != null)
        {
            //Debug.Log("��������");
            // �������� �ٽ� �ö��
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
            Debug.LogErrorFormat("���Ӹ޴��� ���������� �ҷ����� ����");
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

            // �̴ϸ� �ʱ�ȭ
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
        // �����
        // Debug.Log("���� ����");

        if (!onPlay)
        {
            return;
        }

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


        // ���� ���ھ� �ʱ�ȭ
        AccountManager.instance.InitVariables();

        // ���â �ű��
        GameOver.position = new Vector2(GameOver.position.x, -2400);

        // ����� ��ȯ
        SoundManager.instance.bgmPlay(SoundManager.Bgm.Main);
    }

    public void GameOverButton()
    {
        UnLoadInGameScene();
        OpenMainCanvas();
        OpenBackGround();
        objectManager.OffObjects();
        GameEndVarInit();
        
        // ��ī��Ʈ �Ŵ��� ���� �ѱ�
        AccountManager.instance.OnMainCanvas();
        //ȿ����
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
    }

    public void GameEndWhilePlay()
    {
        if (!onPlay)
        {
            return;
        }

        // ���� ������Ʈ ���� �ߴ�
        spawnManager.StopSpawn();

        // �÷��̾� ���� �ߴ�
        onPlay = false;

        // ���� ���� ���� ������ ���ϱ�
        AccountManager.instance.SetGold();

        // ���� ����
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
