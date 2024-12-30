using TMPro;
using UnityEngine;
public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter instance;
    public TMP_Text killstreakText;
    public TMP_Text highstreakText;
    public TMP_Text highkillsText;
    public static int killstreak;
    int highstreak;
    public static int enemies;

    void Start()
    {
        instance = this;
        highstreakText.text = "HI-STREAK: " + PlayerPrefs.GetInt("HighStreak", 0).ToString();
        ResetStreak();
        enemies = 0;
    }
    void Update()
    {
        UpdateStreak();
        if (killstreak > PlayerPrefs.GetInt("HighStreak", 0))
        {
            PlayerPrefs.SetInt("HighStreak", killstreak);
            highstreakText.text = killstreak.ToString();
        }
        highstreakText.text = "HI-STREAK: " + PlayerPrefs.GetInt("HighStreak", 0).ToString();
    }

    public void ResetStreak()
    {
        killstreak = 0;
        UpdateStreak();
    }
    void UpdateStreak()
    {
        killstreakText.text = "" + killstreak;
        highkillsText.text = "FINAL STREAK: " + killstreak;
    }

    void Reset()
    {
        GameController.instance.ResetGame();
    }
}