using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Pasang script ini di GameObject "SettingsPanel".
/// Hubungkan Slider Music & SFX, serta AudioSource musik & SFX di Inspector.
/// Tidak perlu Audio Mixer - volume diatur langsung lewat AudioSource.volume.
/// </summary>
public class SettingsManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource;   // drag object BGM di sini
    public AudioSource sfxSource;     // drag object SFX di sini (kalau ada)

    [Header("UI Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Panel")]
    public GameObject settingsPanel;

    private const string MUSIC_KEY = "MusicVolume";
    private const string SFX_KEY = "SFXVolume";

    void Start()
    {
        // load volume tersimpan, default 0.75 (75%)
        float savedMusic = PlayerPrefs.GetFloat(MUSIC_KEY, 0.75f);
        float savedSFX = PlayerPrefs.GetFloat(SFX_KEY, 0.75f);

        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;

        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float value)
    {
        if (musicSource != null)
            musicSource.volume = value;

        PlayerPrefs.SetFloat(MUSIC_KEY, value);
    }

    public void SetSFXVolume(float value)
    {
        if (sfxSource != null)
            sfxSource.volume = value;

        PlayerPrefs.SetFloat(SFX_KEY, value);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}