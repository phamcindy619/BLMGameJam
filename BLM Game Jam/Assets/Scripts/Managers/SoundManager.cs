using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Background music source
    public AudioSource musicSource;
    // Sound effects source
    public AudioSource efxSource;
    // Singleton SoundManager
    public static SoundManager instance = null;
    // Toggle volume
    private bool volumeOn = true;

    // Images
    public Sprite volumeOnImage;
    public Sprite volumeOffImage;

    void Start()
    {
        PlayMusic();
    }

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
    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void ToggleSound()
    {
        Button volumeButton = GameObject.Find("VolumeButton").GetComponent<Button>();
        if (volumeOn)
        {
            AudioListener.volume = 0;
            volumeOn = false;
            volumeButton.GetComponent<Image>().sprite = volumeOffImage;
        }
        else
        {
            AudioListener.volume = 1;
            volumeOn = true;
            volumeButton.GetComponent<Image>().sprite = volumeOnImage;
        }
    }
}
