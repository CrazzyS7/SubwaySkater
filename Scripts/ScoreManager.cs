using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI mPlayerScoreText;
    public TextMeshProUGUI mHiScoreText;

    private readonly int mFirstScore = 100;
    private readonly int mSecondScore = 50;
    private readonly int mThirdScore = 25;
    private static int[] mScores;
    private int mHiScore;

    public static int PlayerScore
    { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        mScores = new int[4];
        mScores[0] = PlayerPrefs.GetInt("firstScore", mFirstScore);
        mScores[1] = PlayerPrefs.GetInt("secondScore", mSecondScore);
        mScores[2] = PlayerPrefs.GetInt("thirdScore", mThirdScore);
        PlayerScore = PlayerPrefs.GetInt("playerScore", 0);
        mHiScore = mScores[0];
        return;
    }

    // Update is called once per frame
    void Update()
    {
        mHiScore = (PlayerScore > mHiScore) ? PlayerScore : mHiScore;
        mPlayerScoreText.text = PlayerScore.ToString("D3");
        mHiScoreText.text = mHiScore.ToString("D3");
    }

    public static void AddScore(int _score)
    {
        PlayerScore += _score;
        return;
    }

    public static void SavePlayerScore()
    {
        PlayerPrefs.SetInt("playerScore", PlayerScore);
        return;
    }

    public static void UpdateScore()
    {
        if(PlayerScore > mScores[2])
        {
            mScores[3] = PlayerScore;
            Array.Sort(mScores);
            PlayerPrefs.SetInt("firstScore", mScores[3]);
            PlayerPrefs.SetInt("secondScore", mScores[2]);
            PlayerPrefs.SetInt("thirdScore", mScores[1]);
        }
        return;
    }
}
