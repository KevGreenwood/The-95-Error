using UnityEngine;
public class OSTMusic : MonoBehaviour
{
    public static OSTMusic instance;
    public AudioSource audioSource;
    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioClip song4;
    public GameObject musicPanel;
    public GameObject audioLoudness;

    void Start()
    {
        instance = this;
    }

    public void PlayFirst()
    {
        audioSource.clip = song1;
        Play();
    }
    public void PlaySecond()
    {
        audioSource.clip = song2;
        Play();
    }
    public void PlayThird()
    {
        audioSource.clip = song3;
        Play();
    }
    public void PlayFourth()
    {
        audioSource.clip = song4;
        Play();
    }
    public void Play()
    {
        audioLoudness.SetActive(true);
        audioSource.Play();
        musicPanel.SetActive(false);
        GameControllerM.instance.state = 1;
    }
}