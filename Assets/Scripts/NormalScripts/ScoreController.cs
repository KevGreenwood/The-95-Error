using TMPro;
using UnityEngine;
public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public Animator cam;
    public int score = 0;
    int highscore;
    public AudioSource AS1;
    public AudioSource musicAS;
    public AudioClip clip;
    public AudioClip wohoo;
    bool end;

    void Start()
    {
        instance = this;
        highscoreText.text = "HI-SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        ResetScore();
    }
    void Update()
    {
        if (end && musicAS.volume > 0)
        {
            musicAS.volume -= Time.deltaTime / 10f;
        }
        highscoreText.text = "HI-SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void RaiseScore() //Suma de puntos (+1)
    {
        score++;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoreText.text = score.ToString();
        }
        UpdateScore();
        PlayScore();

        if (score >= 15 && !end)
        {
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            GameController.instance.state = 3;
            Timer.instance.StopWatch();
            cam.SetTrigger("end");
            Invoke("PlayCheer", 5f);
            end = true;
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = score + "";
    }

    void PlayScore()
    {
        AS1.pitch = 1 + score / 20f;
        AS1.PlayOneShot(clip);
    }
    void PlayCheer()
    {
        AS1.pitch = 1;
        AS1.PlayOneShot(wohoo);
    }
}