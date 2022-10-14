using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI mFirstScoreText;
    public TextMeshProUGUI mSecondScoreText;
    public TextMeshProUGUI mThirdScoreText;

    private readonly int mFirstScore = 1000;
    private readonly int mSecondScore = 500;
    private readonly int mThirdScore = 300;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        return;
    }

    public void QuitGame()
    {
        Application.Quit();
        return;
    }

    public void GetHiScore()
    {
        int score = (PlayerPrefs.HasKey("firstScore")) ? PlayerPrefs.GetInt("firstScore") : mFirstScore;
        mFirstScoreText.text = "First - " + score.ToString();

        score = (PlayerPrefs.HasKey("secondScore")) ? PlayerPrefs.GetInt("secondScore") : mSecondScore;
        mSecondScoreText.text = "Second - " + score.ToString();

        score = (PlayerPrefs.HasKey("thirdScore")) ? PlayerPrefs.GetInt("thirdScore") : mThirdScore;
        mThirdScoreText.text = "Third - " + score.ToString();
        return;
    }
}
