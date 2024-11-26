using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ui_Ingame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highestScoreText;
    [SerializeField] GameObject highestScoreImage;
    [SerializeField] float lengthXposModifier = 30;


    void Start()
    {
        highestScoreText.text = $"{ScoreManager.instance.HighestScore}";
        
        int textLength = highestScoreText.text.Length;

        highestScoreImage.GetComponent<RectTransform>().localPosition = 
            new Vector3(highestScoreImage.GetComponent<RectTransform>().localPosition.x - ((textLength - 1) * lengthXposModifier), highestScoreImage.GetComponent<RectTransform>().localPosition.y);
    }

    void Update()
    {
        scoreText.text = ScoreManager.instance.Score.ToString();
    }
}
