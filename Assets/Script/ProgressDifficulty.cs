using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressDifficulty : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public Manager manager;
    public Slider slider;
    float timeCollector = 0;
    float timeDiminisher = 100;
    bool upEnemySpeed = true;

    void Update()
    {
        if(manager.score <= 5000)
        {
            if(slider.value == 1)
            {
                enemySpawner.numOfEnemy += 10;
                timeCollector = 0;
                upEnemySpeed = !upEnemySpeed;
                if(upEnemySpeed)
                {
                    enemySpawner.enemySpeed *= 1.5f;
                }
            }
            timeCollector += Time.deltaTime / timeDiminisher;
            slider.value = timeCollector;
        }
    }
}
