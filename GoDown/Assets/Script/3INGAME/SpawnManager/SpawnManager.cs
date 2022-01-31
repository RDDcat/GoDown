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

    string[] BlockName;

    public bool stopSpawn;

    private void Awake()
    {
        BlockName = new string[] { "Block1", "Block2", "Block3", "Block4", "Block5", "Block6", "CoinBlock1" , "CoinBlock1"};
        try
        {
            objectManager = FindObjectOfType<ObjectManager>();
            gameManager = FindObjectOfType<GameManager>();
            
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
            if(gameManager.blockSpeed > 10)
            {
                if(Random.Range(0, 4) == 1)
                {
                    Spawn();
                }                
            }
            else if (gameManager.blockSpeed > 30)
            {
                int num = Random.Range(0, 4);
                if (num == 1)
                {
                    Spawn();
                    Spawn();
                }
                if(num > 1)
                {
                    Spawn();
                }
            }
        }
        
    }

    void Spawn()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnBlock();
            if(gameManager.blockSpeed < 9f)
            {
                maxSpawnDelay = Random.Range(0.6f, 2f);
            }
            else if (gameManager.blockSpeed < 24f && gameManager.blockSpeed >= 9f)
            {
                maxSpawnDelay = Random.Range(0.3f, 1.4f);
            }
            else if (gameManager.blockSpeed < 48f && gameManager.blockSpeed >= 24f)
            {
                maxSpawnDelay = Random.Range(0.3f, 1.1f);
            }
            else
            {
                maxSpawnDelay = Random.Range(0.15f, 0.75f);
            }
            curSpawnDelay = 0;
        }
    }

    private void SpawnBlock()
    {
        int ranBlock = Random.Range(0, 2);
        int ranPoint = Random.Range(0, 9);

        GameObject obj;

        if (gameManager.blockHP <= 10)
        {
            obj = objectManager.MakeObj(BlockName[ranBlock]);
        }
        else if(gameManager.blockHP > 10 && 20 > gameManager.blockHP)
        {
            obj = objectManager.MakeObj(BlockName[ranBlock+2]);
        }
        else
        {
            obj = objectManager.MakeObj(BlockName[ranBlock+4]);
        }

        obj.GetComponent<Block>().SetBlock(gameManager.blockHP, gameManager.blockSpeed, gameManager.blockScore, gameManager.blockResistance);
        obj.transform.position = spawnPoints[ranPoint].position;
    }

    private void SpawnLayerBlock()
    {        
        for(int i =0; i < spawnPoints.Length; i++)
        {
            try
            {
                GameObject obj = objectManager.MakeObj(BlockName[i % 2]);
                obj.GetComponent<Block>().SetBlock(gameManager.blockHP, 0, gameManager.blockScore, gameManager.blockResistance);
                obj.transform.position = spawnPoints[i].position;
            }
            catch
            {
                GameObject obj = objectManager.MakeObj(BlockName[(i % 2) + 2]);
                obj.GetComponent<Block>().SetBlock(gameManager.blockHP, 0, gameManager.blockScore, gameManager.blockResistance);
                obj.transform.position = spawnPoints[i].position;
            }
            
        }
        
    }

    public float SpawnLayer(int layerNumber)
    {
        StartCoroutine(SpawnLayerCorutine(layerNumber/5, 0.2f));
        return 3f + (layerNumber * 0.1f);
    }

    IEnumerator SpawnLayerCorutine(int layerNumber, float waitSecond)
    {
        for(int i =0; i< layerNumber; i++)
        {
            SpawnLayerBlock();
            yield return new WaitForSeconds(waitSecond);
        }

        yield return new WaitForSeconds(3f);
        StartSpawn();
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
