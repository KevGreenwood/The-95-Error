using UnityEngine;
public class CameraControllerMenu : MonoBehaviour
{
    public Camera cam;
    float size1;
    float size2;
    float timer;
    bool goingUp = true;

    void Start()
    {
        size1 = 5.5f;
        size2 = 5.75f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        cam.orthographicSize = Mathf.Lerp(size1, size2, timer / 15f);
        if (timer > 15f)
        {
            timer = 0f;
            goingUp = !goingUp;
            if (goingUp)
            {
                Start();
            }
            else
            {
                size1 = 5.75f;
                size2 = 5.5f;
            }
        }
    }
}