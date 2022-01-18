using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject Block1Prefab;
    public GameObject Block2Prefab;
    public GameObject coinBlock1Prefab;
    public GameObject coinBlock2Prefab;
    public GameObject coinPrefab;

    GameObject[] Block1;
    GameObject[] Block2;

    GameObject[] coinBlock1;
    GameObject[] coinBlock2;

    GameObject[] coin;

    GameObject[] targetPool;

    public bool isGenerated;

    private void Awake()
    {
        Debug.Log("오브젝트 풀링");
        Block1 = new GameObject[30];
        Block2 = new GameObject[30];

        coinBlock1 = new GameObject[30];
        coinBlock2 = new GameObject[30];

        coin = new GameObject[20];

        Generate();
    }

    void Generate()
    {
        if (!isGenerated)
        {
            Debug.Log("생성");
            for (int i = 0; i < Block1.Length; i++)
            {
                Debug.Log("Block1 생성");
                Block1[i] = Instantiate(Block1Prefab);
                Block1[i].SetActive(false);
            }
            for (int i = 0; i < Block2.Length; i++)
            {
                Debug.Log("Block2 생성");
                Block2[i] = Instantiate(Block2Prefab);
                Block2[i].SetActive(false);
            }

            for (int i = 0; i < coinBlock1.Length; i++)
            {
                coinBlock1[i] = Instantiate(coinBlock1Prefab);
                coinBlock1[i].SetActive(false);
            }
            for (int i = 0; i < coinBlock2.Length; i++)
            {
                coinBlock2[i] = Instantiate(coinBlock2Prefab);
                coinBlock2[i].SetActive(false);
            }

            for (int i = 0; i < coin.Length; i++)
            {
                coin[i] = Instantiate(coinPrefab);
                coin[i].SetActive(false);
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
