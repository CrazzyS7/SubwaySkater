using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI mCurrentLevelText;
    public TextMeshProUGUI mNextLevelText;
    public GameObject mLevelCompletePanel;
    public Slider mGameProgressSlider;
    //public static int mCurrentLevel = 0;
    public GameObject mGameOverPanel;
    public GameObject mGamePlayPanel;

    private static GameManager instance;

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

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        IsGameOver = false;
        IsLevelCompleted = false;
        Time.timeScale = 1;
        PassedRingNum = 0;
        return;
    }

    // Update is called once per frame
    void Update()
    {
        mCurrentLevelText.text = CurrentLevelNum.ToString();
        mNextLevelText.text = (CurrentLevelNum + 1).ToString();
        mGameProgressSlider.value = (PassedRingNum * 100 / (TowerManager.NumberOfRings + 1));

        if(IsGameOver)
        {
            Time.timeScale = 0.0f;
            PlayerPrefs.DeleteKey("currentLevel");
            mGameOverPanel.SetActive(true);
            mGamePlayPanel.SetActive(false);
        }
        
        if(IsLevelCompleted)
        {
            PlayerPrefs.SetInt("currentLevel", CurrentLevelNum + 1);
            mLevelCompletePanel.SetActive(true);
            mGamePlayPanel.SetActive(false);
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
}
