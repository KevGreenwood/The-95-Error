using UnityEngine;
public class UserMusic : MonoBehaviour
{
    public static UserMusic instance;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject ostMusic;

    void Start()
    {
        instance = this;
    }

    public void UserMusicIsPlaying()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        ostMusic.SetActive(false);
    }
}