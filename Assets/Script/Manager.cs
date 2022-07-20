using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : Singleton<Manager>
{
    public PlayerController player;
    public EnemySpawner enemySpawner;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highsScoreText;
    public CanvasGroup OverBG;
    public float fadeSpeed = 1;
    public float timeBeforeFade;
    public float score;
    private float scoreAmountPS;
    private float highSCore;
    private float pastScore;
    public int numOfEnemy;
    private bool needToSave;

    void Start()
    {
        OverBG.gameObject.SetActive(true);
        OverBG.alpha = 0;
        needToSave = true;
        highSCore = GetScore();
        highsScoreText.text = "High Score: " + Mathf.RoundToInt(highSCore).ToString();
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
            scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();

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
                GameOver();
            }
        }
    }

    void GameOver()
    {
        StartCoroutine(ShowGameOver());
    }

    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(timeBeforeFade);
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            OverBG.alpha = alpha;

            yield return null;
        }
        OverBG.alpha = 1;
    }

    public void PlayAgain()
    {

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void PlayQuit()
    {
        Application.Quit();
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
