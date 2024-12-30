using UnityEngine;
public class AnimManagerM : MonoBehaviour
{
    public GameObject intro;
    public Animator introAnim;
    public Animator transAnim;
    public Animator camAnim;
    float timer;

    void Update()
    {
        if (GameControllerM.instance.state == 1)
        {
            GameControllerM.instance.state = 2;
            transAnim.SetTrigger("out");
            intro.SetActive(true);
            introAnim.SetTrigger("action");
            timer = 0;
        }

        if (GameControllerM.instance.state == 2)
        {
            timer += Time.deltaTime;

            if (timer >= 46f && !ColorControllerM.instance.start)
            {
                ColorControllerM.instance.start = true;
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
                ColorControllerM.instance.start = true;
            }
        }
    }

    void StartGame()
    {
        GameControllerM.instance.StartGame();
    }
}