using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Score Info")]
    [SerializeField] int heightScoreModifier = 100;
    [SerializeField] int enemyScoreModifier = 300;
    public int score = 0;

    float highestYpos = 0;
    float PlayerYpos = 0;
    int highestScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }

        highestScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void Start()
    {
        score = 0;
    }

    private void Update()
    {
        PlayerYpos = PlayerManager.instance.player.transform.position.y;

        if (PlayerYpos > highestYpos)
        {
            float modifier = PlayerYpos - highestYpos;
            highestYpos = PlayerYpos;

            AddScore(Mathf.RoundToInt(modifier * heightScoreModifier));
        }
    }

    public void AddScore(int _scoreModifier)
    {
        score += _scoreModifier;
    }

    public void AddEnemyScore()
    {
        score += enemyScoreModifier;
    }

    public bool UpdateHighestScore() 
    {
        if (score > highestScore) 
        {
            PlayerPrefs.SetInt("highScore", score);
            return true;
        }
        return false;
    }
}
