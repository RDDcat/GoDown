using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] blocks;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    private void FixedUpdate()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnBlock();
            maxSpawnDelay = Random.Range(0.5f, 2f);
            curSpawnDelay = 0;
        }
    }

    private void SpawnBlock()
    {
        int ranBlock = Random.Range(0, 2);
        int ranPoint = Random.Range(0, 9);

        Instantiate(blocks[ranBlock], spawnPoints[ranPoint]);
    }
}
