using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject Block1Prefab;
    public GameObject Block2Prefab;
    public GameObject coinBlockPrefab;
    public GameObject layerBlockPrefab;
    public GameObject coinPrefab;

    GameObject[] Block1;
    GameObject[] Block2;

    GameObject[] coinBlock;
    GameObject[] layerBlock;

    GameObject[] coin;


    private void Start()
    {
        Block1 = new GameObject[30];
        Block2 = new GameObject[30];

        coinBlock = new GameObject[20];
        layerBlock = new GameObject[100];

        coin = new GameObject[20];

        Generate();
    }

    void Generate()
    {
        Debug.Log("持失");
        for(int i =0; i < Block1.Length; i++)
        {
            Debug.Log("Block1 持失");
            Block1[i] = Instantiate(Block1Prefab);
            Block1[i].SetActive(false);
        }
        for (int i = 0; i < Block2.Length; i++)
        {
            Debug.Log("Block2 持失");
            Block2[i] = Instantiate(Block2Prefab);
            Block2[i].SetActive(false);
        }

        for (int i = 0; i < coinBlock.Length; i++)
        {
            coinBlock[i] = Instantiate(coinBlockPrefab);
            coinBlock[i].SetActive(false);
        }
        for (int i = 0; i < layerBlock.Length; i++)
        {
            layerBlock[i] = Instantiate(layerBlockPrefab);
            layerBlock[i].SetActive(false);
        }

        for (int i = 0; i < coin.Length; i++)
        {
            coin[i] = Instantiate(coinPrefab);
            coin[i].SetActive(false);
        }
    }


}
