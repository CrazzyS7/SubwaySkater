using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mGameOverPanel;
    public GameObject mLevelCompletePanel;

    public static bool IsGameOver
    { get; set; }

    public static bool LevelCompleted
    { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = false;
        LevelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGameOver)
        {
            Time.timeScale = 0.0f;
            mGameOverPanel.SetActive(true);
        }
        
        if(LevelCompleted)
        {
            mLevelCompletePanel.SetActive(true);
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
