using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Blocks blocks;

    public GameObject Block1Prefab;
    public GameObject Block2Prefab;
    public GameObject Block3Prefab;
    public GameObject Block4Prefab;
    public GameObject Block5Prefab;
    public GameObject Block6Prefab;
    public GameObject coinBlock1Prefab;
    public GameObject coinBlock2Prefab;
    public GameObject coinPrefab;

    GameObject[] Block1;
    GameObject[] Block2;

    GameObject[] Block3;
    GameObject[] Block4;

    GameObject[] Block5;
    GameObject[] Block6;

    GameObject[] coinBlock1;
    GameObject[] coinBlock2;

    GameObject[] coin;

    GameObject[] targetPool;

    public bool isGenerated;

    private void Awake()
    {
        // Debug.Log("오브젝트 풀링");
        Block1 = new GameObject[100];
        Block2 = new GameObject[100];

        Block3 = new GameObject[100];
        Block4 = new GameObject[100];

        Block5 = new GameObject[100];
        Block6 = new GameObject[100];

        coinBlock1 = new GameObject[30];
        coinBlock2 = new GameObject[30];

        coin = new GameObject[10];

        Generate();
        blocks.MappingAllBlocks();        
    }

    public void AllFade()
    {
        for (int i = 0; i < Block1.Length; i++)
        {   
            Block1[i].SetActive(false);
        }
        for (int i = 0; i < Block2.Length; i++)
        {
            Block2[i].SetActive(false);
        }
        for (int i = 0; i < Block3.Length; i++)
        {
            Block3[i].SetActive(false);
        }
        for (int i = 0; i < Block4.Length; i++)
        {
            Block4[i].SetActive(false);
        }
        for (int i = 0; i < Block6.Length; i++)
        {
            Block6[i].SetActive(false);
        }
        for (int i = 0; i < Block5.Length; i++)
        {
            Block5[i].SetActive(false);
        }

        for (int i = 0; i < coinBlock1.Length; i++)
        {
            coinBlock1[i].SetActive(false);
        }
        for (int i = 0; i < coinBlock2.Length; i++)
        {
            coinBlock2[i].SetActive(false);
        }

        for (int i = 0; i < coin.Length; i++)
        {
            coin[i].SetActive(false);
        }
    }

    void Generate()
    {
        if (!isGenerated)
        {
            // Debug.Log("생성");
            for (int i = 0; i < Block1.Length; i++)
            {
                Block1[i] = Instantiate(Block1Prefab);
            }
            for (int i = 0; i < Block2.Length; i++)
            {
                Block2[i] = Instantiate(Block2Prefab);
            }
            for (int i = 0; i < Block3.Length; i++)
            {
                Block3[i] = Instantiate(Block3Prefab);
            }
            for (int i = 0; i < Block4.Length; i++)
            {
                Block4[i] = Instantiate(Block4Prefab);
            }
            for (int i = 0; i < Block5.Length; i++)
            {
                Block5[i] = Instantiate(Block5Prefab);
            }
            for (int i = 0; i < Block6.Length; i++)
            {
                Block6[i] = Instantiate(Block6Prefab);
            }

            for (int i = 0; i < coinBlock1.Length; i++)
            {
                coinBlock1[i] = Instantiate(coinBlock1Prefab);
            }
            for (int i = 0; i < coinBlock2.Length; i++)
            {
                coinBlock2[i] = Instantiate(coinBlock2Prefab);
            }

            for (int i = 0; i < coin.Length; i++)
            {
                coin[i] = Instantiate(coinPrefab);
            }
            isGenerated = true;
        }
    }

    public void OffObjects()
    {
        for (int i = 0; i < Block1.Length; i++)
        {
            Block1[i].SetActive(false);
        }
        for (int i = 0; i < Block2.Length; i++)
        {
            Block2[i].SetActive(false);
        }
        for (int i = 0; i < Block3.Length; i++)
        {
            Block3[i].SetActive(false);
        }
        for (int i = 0; i < Block4.Length; i++)
        {
            Block4[i].SetActive(false);
        }
        for (int i = 0; i < Block5.Length; i++)
        {
            Block5[i].SetActive(false);
        }
        for (int i = 0; i < Block6.Length; i++)
        {
            Block6[i].SetActive(false);
        }

        for (int i = 0; i < coinBlock1.Length; i++)
        {
            coinBlock1[i].SetActive(false);
        }
        for (int i = 0; i < coinBlock2.Length; i++)
        {
            coinBlock2[i].SetActive(false);
        }

        for (int i = 0; i < coin.Length; i++)
        {
            coin[i].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        
        switch (type)
        {
            case "Block1":
                targetPool = Block1;                
                break;
            case "Block2":
                targetPool = Block2;
                break;
            case "Block3":
                targetPool = Block3;
                break;
            case "Block4":
                targetPool = Block4;
                break;
            case "Block5":
                targetPool = Block5;
                break;
            case "Block6":
                targetPool = Block6;
                break;

            case "CoinBlock1":
                targetPool = coinBlock1;
                break;
            case "CoinBlock2":
                targetPool = coinBlock2;
                break;

            case "Coin":
                targetPool = coin;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }

        Debug.LogError("오브젝트 풀링 에러");
        return null;
    }   

}
