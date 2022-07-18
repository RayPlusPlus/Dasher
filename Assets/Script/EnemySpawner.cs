using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numOfEnemy = 25;
    public float maxEnemySpawn;
    public float timePassed = 1.5f;
    public Enemy enemy;
    public Collider2D[] spawnPoints;
    public GameObject enemyParent;

    private List<Enemy> spawnedEnemy;
    private GameObject player;
    private float elapsedTime = 0;

    public void EnemyPool()
    {
        spawnedEnemy = new List<Enemy>();
        for (int i=0; i< maxEnemySpawn; i++)
        {
            Enemy e=Instantiate(enemy);
            e.SetTarget(player);
            e.transform.SetParent(enemyParent.transform);
            e.gameObject.SetActive(false);
            spawnedEnemy.Add(e);
        }
    }

    public void SetPlayer(PlayerController playerController)
    {
        player = playerController.gameObject;
    }

    void Update()
    {
        if(spawnedEnemy != null)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= timePassed)
            {
                ReleaseEnemies(numOfEnemy);
                elapsedTime = 0;
            }
        }
    }

    void ReleaseEnemies(int enemyCount)
    {
        int foundEnemies = 0;
        for (int i=0; i< spawnedEnemy.Count; i++)
        {
            if (!spawnedEnemy[i].gameObject.activeSelf)
            {
                spawnedEnemy[i].transform.position = GetRandomPosition();
                spawnedEnemy[i].gameObject.SetActive(true);
                foundEnemies += 1;
            }
            if (foundEnemies>=enemyCount)
            {
                return;
            }

        }
    }

    Vector2 GetRandomPosition()
    {
        int areaID = Random.Range(0, spawnPoints.Length);
        Bounds bounds = spawnPoints[areaID].bounds;
        Vector2 position = new Vector2(
            Random.Range(bounds.min.x, bounds.max.x), 
            Random.Range(bounds.min.y, bounds.max.y)
        );

        return position;
    }
}
