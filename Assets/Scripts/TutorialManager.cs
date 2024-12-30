using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    public GameObject intro;
    public GameObject buttons;
    public Animator introAnim;
    public Animator buttonsAnim;
    float timer;

    void Update()
    {
        buttonsAnim.SetTrigger("action");
        introAnim.SetTrigger("action");
        timer = 0;
        timer += Time.deltaTime;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}