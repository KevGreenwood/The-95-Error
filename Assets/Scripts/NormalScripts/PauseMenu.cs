using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject menu;
    public InputController inputController;
    public SpriteRenderer cross;
    //PostFX
    public Volume volume;
    private ChromaticAberration chromAberration;
    private Vignette vignette;

    void Start()
    {
        volume.profile.TryGet(out vignette);
        vignette.intensity.value = 0.25f;
        volume.profile.TryGet(out chromAberration);
        chromAberration.intensity.value = 0.1f;
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

        if (GameController.instance.state == 3)
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
        cross.color = new Color(0.1764706f, 0.1764706f, 0.1764706f, 1f);
    }
    void Pause()
    {
        inputController.playerInputEnabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        vignette.intensity.value = 0.25f;
        chromAberration.intensity.value = 0.1f;
        cross.color = Color.white;
    }

    public void Restart()
    {
        SceneManager.LoadScene("NormalMode");
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