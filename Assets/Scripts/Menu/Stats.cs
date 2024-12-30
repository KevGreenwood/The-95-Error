using TMPro;
using UnityEngine;
public class Stats : MonoBehaviour
{
    public TMP_Text highstreakTextM;
    public TMP_Text highstreakText;
    public TMP_Text highscoreText;
    public TMP_Text highscoreTextM;

    void Start()
    {
        highstreakTextM.text = "HI-STREAK: " + PlayerPrefs.GetInt("HighStreak_M", 0).ToString();
        highscoreTextM.text = "HI-SCORE: " + PlayerPrefs.GetInt("HighScore_M", 0).ToString();
        highstreakText.text = "HI-STREAK: " + PlayerPrefs.GetInt("HighStreak", 0).ToString();
        highscoreText.text = "HI-SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void ResetStats()
    {
        PlayerPrefs.SetInt("HighStreak_M", 0);
        PlayerPrefs.SetInt("HighScore_M", 0);
        PlayerPrefs.SetInt("HighStreak", 0);
        PlayerPrefs.SetInt("HighScore", 0);
        highstreakTextM.text = "HI-STREAK: 0";
        highscoreTextM.text = "HI-SCORE: 0";
        highstreakText.text = "HI-STREAK: 0";
        highscoreText.text = "HI-SCORE: 0";
    }
}