using UnityEngine;
public class EnemyAudio : MonoBehaviour
{
    public static EnemyAudio instance;
    public AudioSource AS2;
    public AudioClip enemyHit;

    void Start()
    {
        instance = this;
    }

    public void PlayEnemyHit()
    {
        AS2.pitch = Random.Range(0.9f, 1.1f);
        AS2.PlayOneShot(enemyHit);
    }
}