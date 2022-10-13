using UnityEngine;

public class GameMAnager : MonoBehaviour
{
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
        }    
    }

    public static bool IsGameOver
    { get; set; }

    public static bool LevelCompleted
    { get; set; }
}
