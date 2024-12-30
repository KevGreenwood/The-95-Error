using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PauseMenuM : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject menu;
    public InputControllerM inputController;
    public SpriteRenderer cross;
    public AudioSource ostSource;
    public AudioSource userSource;
    //PostFX
    public Volume volume;
    private ChromaticAberration chromAberration;
    private Vignette vignette;

    void Start()
    {
        volume.profile.TryGet(out vignette);
        vignette.intensity.value = 0.3f;
        volume.profile.TryGet(out chromAberration);
        chromAberration.intensity.value = 0.15f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (GameControllerM.instance.state == 4)
        {
            menu.SetActive(false);
        }
    }

    public void Resume()
    {
        inputController.playerInputEnabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ostSource.UnPause();
        userSource.UnPause();
        cross.color = new Color(0f, 0.4705883f, 0.8431373f, 1f);
    }
    void Pause()
    {
        inputController.playerInputEnabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ostSource.Pause();
        userSource.Pause();
        vignette.intensity.value = 0.3f;
        chromAberration.intensity.value = 0.15f;
        cross.color = Color.white;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MusicalMode");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}