using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public GameObject cellSpawnPrefab;
    public GameObject cellEnemyPrefab;
    public GameObject cellTowerPrefab;
    public int cellRows;
    public int cellColumns;
    public float cellSize;

    private Vector3 startCellSpawnPosition;
    private Vector3 startCellEnemyPosition;
    private Vector3 startCellTowerPosition;

    public GameObject enemySpawner;
    public GameObject towerArena;





    void Start()
    {
        startCellSpawnPosition = transform.position;
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    void GenerateMap()
    {
        for (int col = 0; col < cellColumns; col++)
        {
            Vector3 cellPosition = startCellSpawnPosition + new Vector3(col * cellSize, 0, 0);
            GameObject newCell = Instantiate(cellSpawnPrefab, cellPosition, Quaternion.identity, enemySpawner.transform);
            newCell.name = $"{col + 1}";

        }

        startCellEnemyPosition = new Vector3(startCellSpawnPosition.x, startCellSpawnPosition.y -  cellSize, startCellSpawnPosition.z);


        for (int row = 0; row < cellRows; row++)
        {
            for (int col = 0; col < cellColumns; col++)
            {
                Vector3 cellPosition = startCellEnemyPosition + new Vector3(col * cellSize, row * -cellSize, 0);
                GameObject newCell = Instantiate(cellEnemyPrefab, cellPosition, Quaternion.identity, transform);
            }
        }

        startCellTowerPosition = new Vector3(startCellEnemyPosition.x, startCellEnemyPosition.y - (cellRows * cellSize), startCellEnemyPosition.z);

        for (int row = 0; row < cellRows; row++)
        {
            for (int col = 0; col < cellColumns; col++)
            {
                Vector3 cellPosition = startCellTowerPosition + new Vector3(col * cellSize, row * -cellSize, 0);
                GameObject newCell = Instantiate(cellTowerPrefab, cellPosition, Quaternion.identity, towerArena.transform);
            }
        }
    }
}
