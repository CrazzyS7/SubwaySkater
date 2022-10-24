using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    private readonly int mGameMusicIndex = 4;
    private static AudioManager mInstance;

    public Sound[] mSounds;

    void Start()
    {
        if (mInstance != null)
            Destroy(gameObject);
        else
        {
            mInstance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in mSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        return;
    }

    private void Update()
    {
        //MuteMusic();
        return;
    }

    public void Play(string _sound)
    {
        if (!ButtonsManager.IsMute)
        {
            Sound s = Array.Find(mSounds, item => item.name == _sound);
            s.source.Play();
        }
        return;
    }

    public void MuteMusic(bool _mute)
    {
        if (_mute)
            mSounds[mGameMusicIndex].source.Stop();
        else
            mSounds[mGameMusicIndex].source.Play();

        return;
    }
}
