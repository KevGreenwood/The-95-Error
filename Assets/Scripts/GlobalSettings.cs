using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMP_Text musicvolText;
    [SerializeField] TMP_Text sfxvolText;
    [SerializeField] Toggle screenToggle;
    [SerializeField] Toggle fpsToggle;
    [SerializeField] GameObject fpsCanvas;
    [SerializeField] TMP_Dropdown resDropdown;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SFXVolume";

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        if (Screen.fullScreen)
        {
            screenToggle.isOn = true;
        }
        else
        {
            screenToggle.isOn = false;
            Screen.SetResolution(854, 480, false);
        }
        resDropdown.value = PlayerPrefs.GetInt("Resolution", resDropdown.value);
        fpsToggle.isOn = FPSToggleStatus();
    }
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(MIXER_MUSIC, musicSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat(MIXER_SFX, sfxSlider.value);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            ShowFPS();
        }
    }
    void OnDisable()
    {
        PlayerPrefs.SetFloat(MIXER_MUSIC, musicSlider.value);
        PlayerPrefs.SetFloat(MIXER_SFX, sfxSlider.value);
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        musicvolText.text = ((int)(value * 100)).ToString();
    }
    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        sfxvolText.text = ((int)(value * 100)).ToString();
    }

    public void SetFullscreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
        if (screenToggle.isOn == false)
        {
            int res = resDropdown.value;
        }
    }
    public void WindowedResolutions(int val)
    {
        if (val == 0)
        {
            Screen.SetResolution(854, 480, false); // Works 100%
            screenToggle.isOn = false;
            PlayerPrefs.SetInt("Resolution", 0);
        }
        if (val == 1)
        {
            Screen.SetResolution(1280, 720, false);
            screenToggle.isOn = false;
            PlayerPrefs.SetInt("Resolution", 1);
        }
        if (val == 2)
        {
            Screen.SetResolution(1920, 1080, false);
            screenToggle.isOn = false;
            PlayerPrefs.SetInt("Resolution", 2);
        }
    }

    public void ShowFPS()
    {
        fpsCanvas.SetActive(!fpsCanvas.activeSelf);
        SaveFPSToggle();
    }
    private void SaveFPSToggle()
    {
        int value = fpsToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("ShowFPS", value);
    }
    private bool FPSToggleStatus()
    {
        int defaultToggleState = 0;
        return PlayerPrefs.GetInt("ShowFPS", defaultToggleState) == 1;
    }

    public void MainMenu()  // Game Scenes
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NormalMode()
    {
        SceneManager.LoadScene("NormalMode");
    }
    public void MusicalMode()
    {
        SceneManager.LoadScene("MusicalMode");
    }
}