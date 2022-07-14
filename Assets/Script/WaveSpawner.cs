using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
 
    private Wave currentWave;
 
    [SerializeField]
    private Collider2D[] spawnpoints;
 
    private float timeBtwnSpawns;
    private int i = 0;
 
    private bool stopSpawning = false;
 
    private void Awake()
    {
 
        currentWave = waves[i];
        timeBtwnSpawns = currentWave.TimeBeforeThisWave;
    }
 
    private void Update()
    {
        if(stopSpawning)
        {
            return;
        }
 
        if (Time.time >= timeBtwnSpawns)
        {
            SpawnWave();
            IncWave();
 
            timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }
    }
 
    private void SpawnWave()
    {
        
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            int enemyType = Random.Range(0, currentWave.EnemiesInWave.Length);
            int areaID = Random.Range(0, spawnpoints.Length);
            Bounds bounds = spawnpoints[areaID].bounds;
            Vector2 position = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x), 
                Random.Range(bounds.min.y, bounds.max.y)
            );
 
            Instantiate(currentWave.EnemiesInWave[enemyType], position, spawnpoints[areaID].transform.rotation);
        }
    }
 
    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }
    
}