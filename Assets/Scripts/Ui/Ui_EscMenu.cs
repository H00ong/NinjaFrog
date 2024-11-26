using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui_EscMenu : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;

    private void OnEnable()
    {
        Time.timeScale = 0f;

        resumeButton.interactable = true;
        restartButton.interactable = true;
        exitButton.interactable = true;
    }

    public void OnResumeButtonPressed() 
    {
        Time.timeScale = 1f;

        gameObject.SetActive(false);
        resumeButton.interactable = false;
    }

    public void OnRestartButtonPressed() 
    {
        Time.timeScale = 1f;

        gameObject.SetActive(false);
        restartButton.interactable = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnExitButtonPressed() 
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
