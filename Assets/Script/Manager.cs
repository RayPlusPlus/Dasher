using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : Singleton<Manager>
{
    public PlayerController player;
    public EnemySpawner enemySpawner;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highsScoreText;
    private float score;
    private float scoreAmountPS;
    private float highSCore;
    private bool needToSave;

    void Start()
    {
        needToSave = true;
        highSCore = GetScore();
        highsScoreText.text = Mathf.RoundToInt(highSCore).ToString();
        enemySpawner.SetPlayer(player);
        enemySpawner.EnemyPool();
        score = 0;
        scoreAmountPS = 10;
    }

    void Update()
    {
        if (player != null)
        {
            score += scoreAmountPS * Time.deltaTime;
            print(score);
            scoreText.text = Mathf.RoundToInt(score).ToString();
        }
        else
        {
            if(needToSave)
            {
                if(highSCore < score)
                {
                    SetScore();
                }
                needToSave = false;
            }
        }
    }

    public void SetScore()
    {
        PlayerPrefs.SetFloat("score", score);
    }

    public float GetScore()
    {
        return PlayerPrefs.GetFloat("score");
    }
}
