using UnityEngine;
public class InputControllerM : MonoBehaviour
{
    public static InputControllerM instance;
    public PlayerControllerM playerController;
    public bool leftClick;
    public bool rightClick;
    public bool w;
    public bool playerInputEnabled = true;
    bool inputGet; // Verify if the input is enable or not, Unity u really pissed me off -.-

    void Start()
    {
        instance = this;
    }
    void Update()
    {
        inputGet = false;
        leftClick = false;
        rightClick = false;
        w = false;

        if (Input.GetMouseButtonDown(0))
        {
            leftClick = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            rightClick = true;
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            w = true;
        }
    }
}