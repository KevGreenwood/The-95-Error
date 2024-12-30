using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public TMP_Text currentTimeText;
    public TMP_Text endTimeText;
    public bool stopwatchActive = false;
    public float currentTime;

    void Start()
    {
        instance = this;
        currentTime = 0;
    }
    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = "TIME " + time.ToString(@"mm\:ss");
        endTimeText.text = "FINAL TIME " + time.ToString(@"mm\:ss");
    }

    public void StartWatch()
    {
        stopwatchActive = true;
    }
    public void StopWatch()
    {
        stopwatchActive = false;
    }
}