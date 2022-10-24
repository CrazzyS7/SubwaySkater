using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI mSecondScoreText;
    public TextMeshProUGUI mThirdScoreText;
    public TextMeshProUGUI mFirstScoreText;
    public TextMeshProUGUI mSoundMuteText;

    private readonly int mFirstScore = 100;
    private readonly int mSecondScore = 50;
    private readonly int mThirdScore = 25;

    private void Start()
    {
        GetHiScore();
        return;
    }

    public void GetHiScore()
    {
        int score = PlayerPrefs.GetInt("firstScore", mFirstScore);
        mFirstScoreText.text = "First - " + score.ToString();

        score = PlayerPrefs.GetInt("secondScore", mSecondScore);
        mSecondScoreText.text = "Second - " + score.ToString();

        score = PlayerPrefs.GetInt("thirdScore", mThirdScore);
        mThirdScoreText.text = "Third - " + score.ToString();
        return;
    }
}
