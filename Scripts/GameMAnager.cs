using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI mCurrentLevelText;
    public TextMeshProUGUI mLevelScoreText;
    public TextMeshProUGUI mNextLevelText;
    public TextMeshProUGUI mGameScoreText;
    public GameObject mLevelCompletePanel;
    public Slider mGameProgressSlider;
    public GameObject mGameOverPanel;
    public GameObject mGamePlayPanel;
    public GameObject mPausePanel;
    public Image mDragRotate;

    private bool mIsDelay = true;
    private int mDelayTime = 3;

    public static bool IsPaused
    { get; set; }

    public static bool IsGameOver
    { get; set; }

    public static bool IsLevelCompleted
    { get; set; }

    public static int PassedRingNum
    { get; set; }

    public static int CurrentLevelNum
    { get; set; }

    private void Awake()
    {
        CurrentLevelNum = PlayerPrefs.GetInt("currentLevel", 1);
        return;
    }

    void Start()
    {
        IsPaused = false;
        IsGameOver = false;
        IsLevelCompleted = false;
        Time.timeScale = 1;
        PassedRingNum = 0;
        FindObjectOfType<AudioManager>().Play("gameMusic");
        StartCoroutine(RemoveDragRotate());
        return;
    }

    void Update()
    {
        mPausePanel.SetActive(IsPaused);
        mCurrentLevelText.text = CurrentLevelNum.ToString();
        mNextLevelText.text = (CurrentLevelNum + 1).ToString();
        mGameProgressSlider.value = (PassedRingNum * 100 / (TowerManager.NumberOfRings + 1));

        if(IsGameOver)
        {
            mGameScoreText.text = "YOUR SCORE: " + ScoreManager.PlayerScore.ToString("D4");
            Time.timeScale = 0.0f;
            PlayerPrefs.DeleteKey("currentLevel");
            PlayerPrefs.DeleteKey("playerScore");
            mGameOverPanel.SetActive(true);
            mGamePlayPanel.SetActive(false);
            ScoreManager.UpdateScore();
        }
        
        if(IsLevelCompleted)
        {
            mLevelScoreText.text = "YOUR SCORE: " + ScoreManager.PlayerScore.ToString("D4");
            PlayerPrefs.SetInt("currentLevel", CurrentLevelNum + 1);
            mLevelCompletePanel.SetActive(true);
            mGamePlayPanel.SetActive(false);
            ScoreManager.SavePlayerScore();
        }
        return;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        return;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        return;
    }

    public static void PauseGame()
    {
        IsPaused = (IsPaused) ? false : true;
        Time.timeScale = (IsPaused) ? 0.0f : 1.0f;
        return;
    }

    IEnumerator RemoveDragRotate()
    {
        if(mIsDelay)
        {
            yield return new WaitForSeconds(mDelayTime);
            mDragRotate.gameObject.SetActive(false);
            mIsDelay = false;
        }
    }
}
