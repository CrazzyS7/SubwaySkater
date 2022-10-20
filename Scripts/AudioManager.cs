using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;
    public Sound[] sounds;

    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        return;
    }

    public void Play(string sound)
    {
        if (!ButtonsManager.IsMute)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            s.source.Play();
        }
        return;
    }

}
