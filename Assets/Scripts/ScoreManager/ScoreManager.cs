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
    public int Score { get; private set; } = 0;
    public int HighestScore { get; private set; } = 0;

    float highestYpos = 0;
    float PlayerYpos = 0;

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

        HighestScore = PlayerPrefs.GetInt("highScore");
    }

    void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        PlayerYpos = PlayerManager.instance.player.transform.position.y;

        if (PlayerYpos - highestYpos >= 1)
        {
            highestYpos = PlayerYpos;

            AddScore(heightScoreModifier);
        }
    }

    public void AddScore(int _scoreModifier)
    {
        Score += _scoreModifier;
    }

    public void AddEnemyScore()
    {
        Score += enemyScoreModifier;
    }

    public bool UpdateHighestScore() 
    {
        if (Score > HighestScore) 
        {
            PlayerPrefs.SetInt("highScore", Score);
            return true;
        }
        return false;
    }
}
