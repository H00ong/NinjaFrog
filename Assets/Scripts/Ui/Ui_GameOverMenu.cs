using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui_GameOverMenu : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    [SerializeField] GameObject scoreText;
    [SerializeField] TextMeshProUGUI newRecordText;
    [SerializeField] Image newRecordImage;

    private void OnEnable()
    {
        Time.timeScale = 0f;

        int score = ScoreManager.instance.Score;

        scoreText.SetActive(false);

        if (ScoreManager.instance.UpdateHighestScore())
        {
            newRecordImage.gameObject.SetActive(true);
            newRecordText.text = $"Congratulations\nNew Record : {score}";
        }
        else
        {
            newRecordImage.gameObject.SetActive(false);
            newRecordText.text = $"Your Record : {score}";
        }
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
}
