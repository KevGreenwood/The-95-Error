using TMPro;
using UnityEngine;
public class ScoreControllerM : MonoBehaviour
{
    public static ScoreControllerM instance;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text finalScoreTXT;
    public Animator cam;
    public int score = 0;
    int highscore;
    public AudioSource AS1;
    public AudioSource ost;
    public AudioSource userSource;
    public AudioClip clip;
    public AudioClip wohoo;
    bool end;

    void Start()
    {
        instance = this;
        highscoreText.text = "HI-SCORE: " + PlayerPrefs.GetInt("HighScore_M", 0).ToString();
        ResetScore();
    }
    void Update()
    {
        highscoreText.text = "HI-SCORE: " + PlayerPrefs.GetInt("HighScore_M", 0).ToString();
    }

    public void RaiseScore() //Suma de puntos (+1)
    {
        score++;
        if (score > PlayerPrefs.GetInt("HighScore_M", 0))
        {
            PlayerPrefs.SetInt("HighScore_M", score);
            highscoreText.text = score.ToString();
        }
        UpdateScore();
        PlayScore();

        if (!ost.isPlaying && !userSource.isPlaying && !end)
        {
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            GameControllerM.instance.state = 4;
            cam.SetTrigger("end");
            end = true;
        }
    }

    public void LoseScore() // PLEASE STUDY MATH!!! score <= 0; no score >= 0; XDDDD
    {
        score -= 2;
        UpdateScore();
        if (score <= 0)
        {
            ResetScore();
        }
    }
    void UpdateScore()
    {
        scoreText.text = score + "";
        finalScoreTXT.text = "FINAL SCORE: " + score;
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }
    void PlayScore()
    {
        AS1.PlayOneShot(clip);
    }
}