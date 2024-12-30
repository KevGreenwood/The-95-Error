using UnityEngine;
public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    public AudioClip[] clips;
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }
    public void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
    }

    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }
}