using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singelton
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Audio Manager is NULL!");
            return _instance;
        }
    }
    #endregion

    [SerializeField] AudioSource _VOSource, _musicSource;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        _VOSource.Stop();
        _VOSource.clip = clip;
        _VOSource.Play();
    }

    public void PlayMusic()
    {

    }
}
