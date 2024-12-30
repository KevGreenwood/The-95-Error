using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public Animator creditsAnim;
    public Animator menuAnim;
    public GameObject gameModes;
    public GameObject mainMenu;
    public GameObject options;
    public GameObject stats;
    bool inCredits;

    public void GameModes()
    {
        mainMenu.SetActive(false);
        gameModes.SetActive(true);
    }
    public void CloseGameModes()
    {
        mainMenu.SetActive(true);
        gameModes.SetActive(false);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }

    public void Stats()
    {
        mainMenu.SetActive(false);
        stats.SetActive(true);
    }
    public void CloseStats()
    {
        mainMenu.SetActive(true);
        stats.SetActive(false);
    }

    public void Credits()
    {
        creditsAnim.SetTrigger("in");
        menuAnim.SetTrigger("out");
        inCredits = true;
    }
    public void CloseCredits()
    {
        creditsAnim.SetTrigger("out");
        menuAnim.SetTrigger("in");
        inCredits = false;
    }

    public void MainMenu()  // Game Scenes
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void TutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
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