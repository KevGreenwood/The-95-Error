using TMPro;
using UnityEngine;
public class FramerateCounter : MonoBehaviour
{
    public TMP_Text fpsCounter;
    public TMP_Text msCounter;
    float deltaTime = 0.0f;
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        fpsCounter.text = string.Format("{1:0} fps", msec, fps);
        msCounter.text = string.Format("{0:0.0} ms", msec, fps);
    }
}