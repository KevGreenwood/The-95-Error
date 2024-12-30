using TMPro;
using UnityEngine;
public class EnemyCounterM : MonoBehaviour
{
    public static EnemyCounterM instance;
    public TMP_Text killstreakText;
    public TMP_Text highstreakText;
    public TMP_Text highkillsText;
    public static int killstreak;
    int highstreak;
    public int enemies;

    void Start()
    {
        instance = this;
        highstreakText.text = "HI-STREAK: " + PlayerPrefs.GetInt("HighStreak_M", 0).ToString();
        ResetStreak();
        enemies = 0;
    }
    void Update()
    {
        UpdateStreak();

        if (killstreak > PlayerPrefs.GetInt("HighStreak_M", 0))
        {
            PlayerPrefs.SetInt("HighStreak_M", killstreak);
            highstreakText.text = killstreak.ToString();
        }
        highstreakText.text = "HI-STREAK: " + PlayerPrefs.GetInt("HighStreak_M", 0).ToString();
    }

    void UpdateStreak()
    {
        killstreakText.text = "" + killstreak;
        highkillsText.text = "FINAL STREAK: " + killstreak;
    }
    public void ResetStreak()
    {
        killstreak = 0;
        UpdateStreak();
    }
}