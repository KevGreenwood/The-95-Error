using UnityEngine;
public class AnimManager : MonoBehaviour
{
    public GameObject intro;
    public Animator introAnim;
    public Animator transAnim;
    public Animator camAnim;
    float timer;

    void Update()
    {
        if (GameController.instance.state == 0)
        {
            GameController.instance.state = 1;
            transAnim.SetTrigger("out");
            intro.SetActive(true);
            introAnim.SetTrigger("action");
            timer = 0;
        }
        if (GameController.instance.state == 1)
        {
            timer += Time.deltaTime;
            if (timer >= 46f && !ColorController.instance.start)
            {
                ColorController.instance.start = true;
            }
            if (timer >= 4f) //duracion de la intro
            {
                Invoke("StartGame", 1f);
                camAnim.SetTrigger("game");
                timer = 0;
            }
            if (timer >= 5f)
            {
                intro.SetActive(false);
                Invoke("StartGame", 1f);
                camAnim.SetTrigger("game");
                timer = 0;
                ColorController.instance.start = true;
            }
        }
    }
    void StartGame()
    {
        GameController.instance.StartGame();
    }
}