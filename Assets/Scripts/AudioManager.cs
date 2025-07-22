using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public TextMeshProUGUI musicButtonTxt;
    public TextMeshProUGUI soundsButtonTxt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Song");
    }

    public void Update()
    {
        MusicButtonText();
        SoundsButtonText();
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("AudioManager.cs PlayMusic(): Sound not found.");
        }
        else
        {
            musicSource.clip = sound.audioClip;
            musicSource.Play();
            Debug.Log($"AudioManager.cs PlayMusic(): sound.audioClip = {sound.audioClip}");
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("AudioManager.cs PlaySFX(): Sound not found.");
        }
        else
        {
            sfxSource.PlayOneShot(sound.audioClip);
            Debug.Log($"AudioManager.cs PlaySFX(): sound.audioClip = {sound.audioClip}");
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    private void MusicButtonText()
    {
        if (musicSource.mute)
        {
            musicButtonTxt.text = "Music On";
        }
        else
        {
            musicButtonTxt.text = "Music Off";
        }
    }

    private void SoundsButtonText()
    {
        if (sfxSource.mute)
        {
            soundsButtonTxt.text = "Sounds On";
        }
        else
        {
            soundsButtonTxt.text = "Sounds Off";
        }
    }
}
