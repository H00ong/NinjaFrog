using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui_GameStart : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highestScore;
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;


    void Start()
    {
        highestScore.text = "Highest Score:\n" + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void OnStartButtonPressed() 
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnQuitButtonPressed() 
    {
        Application.Quit();
    }
}
