using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Background music source
    public AudioSource musicSource;
    // Sound effects source
    public AudioSource efxSource;
    // Singleton SoundManager
    public static SoundManager instance = null;

    void Awake()
    {
        // Check if there is another SoundManager
        if (instance == null)
            instance = this;
        // Destroy any duplicate
        else if (instance != this)
            Destroy(gameObject);
        
        // Don't destroy SoundManager when reloading the scene
        DontDestroyOnLoad(gameObject);
    }

    // Play single sound effect clip
    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    // Play background music
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
