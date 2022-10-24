using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using TMPro;

public class ButtonsManager : MonoBehaviour
{
    public TextMeshProUGUI mSoundMuteText;

    private int mCharacterIndex = 0;

    public static bool IsMute
    { get; private set; }

    private void Start()
    {
        IsMute = Convert.ToBoolean(PlayerPrefs.GetInt("mute", 0));
        PlayerPrefs.SetInt("character", mCharacterIndex);
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
        FindObjectOfType<AudioManager>().MuteMusic(IsMute);
        return;
    }

    public void CharacterSelector(int _newCharacter)
    {
        mCharacterIndex = _newCharacter;
        PlayerPrefs.SetInt("character", mCharacterIndex);
        return;
    }
}
