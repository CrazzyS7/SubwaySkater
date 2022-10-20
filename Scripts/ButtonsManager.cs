using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public TextMeshProUGUI mSoundMuteText;

    public static bool IsMute
    { get; private set; }

    private void Start()
    {
        IsMute = Convert.ToBoolean(PlayerPrefs.GetInt("mute", 0));
        return;
    }

    private void Update()
    {
        if (IsMute)
        {
            mSoundMuteText.text = "/";
            PlayerPrefs.SetInt("mute", 1);
        }
        else
        {
            mSoundMuteText.text = "";
            PlayerPrefs.SetInt("mute", 0);
        }
        return;
    }

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

    public void ToggleMute()
    {
        IsMute = (IsMute) ? false : true;
        return;
    }
}
