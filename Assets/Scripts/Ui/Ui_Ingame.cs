using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Ui_Ingame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highestScoreText;
    [SerializeField] GameObject highestScoreImage;
    [SerializeField] float lengthXposModifier = 30;
    [SerializeField] TextMeshProUGUI flashCountText;
    [SerializeField] Slider flashSlider;

    Player player;
    Coroutine flashCharging;

    void Start()
    {
        highestScoreText.text = $"{ScoreManager.instance.HighestScore}";
        
        int textLength = highestScoreText.text.Length;

        highestScoreImage.GetComponent<RectTransform>().localPosition = 
            new Vector3(highestScoreImage.GetComponent<RectTransform>().localPosition.x - ((textLength - 1) * lengthXposModifier), highestScoreImage.GetComponent<RectTransform>().localPosition.y);

        player = PlayerManager.instance.player;
    }

    void Update()
    {
        scoreText.text = ScoreManager.instance.Score.ToString();
        
        int flashCount = player.flashCount;
        flashCountText.text = $"x{flashCount.ToString()}";

        if (flashCount == player.maxFlashCount) 
        {
            flashSlider.value = 0;
        }
        else if(flashCharging == null)
        {
            float playerFlashChargingTime = player.flashChargingTime;
            flashCharging = StartCoroutine(Charging(playerFlashChargingTime));            
        }
    }

    IEnumerator Charging(float chargingTime) 
    {
        float elapsedTime = 0f;

        while (elapsedTime <= chargingTime) 
        {
            elapsedTime += Time.deltaTime;
            flashSlider.value = elapsedTime / chargingTime;
            yield return null;
        }

        flashSlider.value = 0;
        player.flashCount++;
        flashCharging = null;
    }
}
