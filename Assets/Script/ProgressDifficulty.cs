using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressDifficulty : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public Manager manager;
    public Slider slider;
    public TextMeshProUGUI levelText;
    private int level = 1;
    float timeCollector = 0;
    float timeDiminisher = 100;
    bool upEnemySpeed = true;

    void Update()
    {
        if(manager.score <= 5000)
        {
            if(slider.value == 1)
            {
                level += 1;
                levelText.text = "Level " + level;
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
        else
        {
            levelText.text = "Max Level";
            slider.value = 1;
        }
    }
}
