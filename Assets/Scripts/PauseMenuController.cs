using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public Logic logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    public void ResumeButton()
    {
        logic.TogglePause();
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
