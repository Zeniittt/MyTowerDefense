using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemies;

    public GameObject normalEnemy;
    public GameObject bossEnemy;

    public int spawnCount;
    public int positionSpawn;
    public string cellSpawnName;


    void Start()
    {
        spawnCount = 0;
        InvokeRepeating("SpawnEnemy", 3f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnEnemy()
    {
        positionSpawn = Random.Range(1, 5);
        if(spawnCount < 4)
        {
            spawnCount++;
        }

        cellSpawnName = positionSpawn.ToString();
        Transform cellSpawn = transform.Find(cellSpawnName);

        if (cellSpawn != null)
        {
            Vector3 position = cellSpawn.position;
            if(spawnCount == 4)
            {
                GameObject newCell = Instantiate(bossEnemy, position, Quaternion.identity, enemies.transform);
                spawnCount = 0;
            } else
            {
                GameObject newCell = Instantiate(normalEnemy, position, Quaternion.identity, enemies.transform);
            }

        }
    }
}
