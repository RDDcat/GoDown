using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager gameManager;
    public ObjectManager objectManager;
    public GameObject[] blocks;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public float blockSpeed;
    public int blockHP;
    string[] BlockName;

    public bool stopSpawn;

    private void Awake()
    {
        BlockName = new string[] { "Block1", "Block2", "CoinBlock1" , "CoinBlock1"};
        try
        {
            objectManager = FindObjectOfType<ObjectManager>();
            gameManager = FindObjectOfType<GameManager>();
            blockSpeed = gameManager.blockSpeed;
            blockHP = gameManager.blockHP;
        }
        catch
        {
            Debug.LogError("스폰매니저가 게임매니저의 맵핑에 실패");
        }
        
    }

    private void FixedUpdate()
    {
        if (!stopSpawn)
        {
            Spawn();
        }
        
    }

    void Spawn()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnBlock();
            maxSpawnDelay = Random.Range(0.5f, 2f);
            curSpawnDelay = 0;
        }
    }

    private void SpawnBlock()
    {
        int ranBlock = Random.Range(0, 4);
        int ranPoint = Random.Range(0, 9);

        GameObject obj = objectManager.MakeObj(BlockName[ranBlock]);
        obj.transform.position = spawnPoints[ranPoint].position;
        obj.GetComponent<Block>().SetBlock(blockHP, blockSpeed);
    }

    public void StopSpawn()
    {
        stopSpawn = true;
    }

    public void StartSpawn()
    {
        stopSpawn = false;
    }
}
