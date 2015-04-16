using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AudioManager : MonoBehaviour {

    static private AudioManager _instance;

    static public AudioManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = (AudioManager)FindObjectOfType(typeof(AudioManager));
            }

            if (!_instance)
            {
                Debug.LogError("AudioManagerをシーンに配置して下さい");
            }

            return _instance;
        }
    }

    private AudioSource BGMsource;
    private AudioSource[] SEsources = new AudioSource[16];

    public AudioClip[] clips;

    void Awake()
    {
        BGMsource = this.gameObject.AddComponent<AudioSource>();
        BGMsource.loop = true;

        for (int i = 0; i < SEsources.Length; i++)
        {
            SEsources[i] = this.gameObject.AddComponent<AudioSource>();
        }

    }

    private void PlayBGM(int index)
    {
        if (BGMsource.clip == clips[index])
        {
            return;
        }

        BGMsource.clip = clips[index];
        BGMsource.Play();

    }

    public void PlayBGMLoop(int index)
    {
        BGMsource.loop = true;
        PlayBGM(index);
    }

    public void PlayBGMOneShot(int index)
    {
        BGMsource.loop = false;
        PlayBGM(index);
    }

    public void PlaySE(int index)
    {
        var waitingSource = SEsources.Where(source => !source.isPlaying).First();

        if (!waitingSource)
        {
            Debug.LogWarning("AudioSourceが枯渇しています");
            return;
        }

        waitingSource.clip = clips[index];
        waitingSource.Play();

    }
}
