using UnityEngine;
public class ExitConfirm : MonoBehaviour
{
    public static bool GameIsQuit = false;
    public GameObject exitConfirmUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsQuit)
            {
                Resume();
            }
            else
            {
                Dialog();
            }
        }
    }

    public void Resume()
    {
        exitConfirmUI.SetActive(false);
        GameIsQuit = false;
    }
    public void Dialog()
    {
        exitConfirmUI.SetActive(true);
        GameIsQuit = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}