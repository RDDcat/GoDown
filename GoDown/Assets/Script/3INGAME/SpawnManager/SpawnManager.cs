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
        BlockName = new string[] { "Block1", "Block2", "CoinBlock1" , "CoinBlock1"};
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
        }
        
    }

    void Spawn()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnBlock();
            maxSpawnDelay = Random.Range(0.15f, 1.25f);
            curSpawnDelay = 0;
        }
    }

    private void SpawnBlock()
    {
        int ranBlock = Random.Range(0, 4);
        int ranPoint = Random.Range(0, 9);

        GameObject obj = objectManager.MakeObj(BlockName[ranBlock]);
        obj.transform.position = spawnPoints[ranPoint].position;
        obj.GetComponent<Block>().SetBlock(gameManager.blockHP, gameManager.blockSpeed, gameManager.blockScore, gameManager.blockResistance);
        
    }

    private void SpawnLayerBlock()
    {
        
        for(int i =0; i < spawnPoints.Length; i++)
        {            
            GameObject obj = objectManager.MakeObj(BlockName[i%2]);
            obj.transform.position = spawnPoints[i].position;
        }
        
    }

    public float SpawnLayer(int layerNumber)
    {
        StartCoroutine(SpawnLayerCorutine(layerNumber/10, 0.2f));
        return 4f + (layerNumber * 0.1f);
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
