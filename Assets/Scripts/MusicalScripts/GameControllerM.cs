using UnityEngine;
public class GameControllerM : MonoBehaviour
{
    public static GameControllerM instance;
    public PlayerControllerM playerControllerM;
    public PointControllerM pointControllerM;
    GameObject[] objs;
    public int state; // 0 = select music, 1 = press start, 2 = intro, 3 = game, 4 = end
    public EnemySpawnerM enemySpawnerM;
    public SpriteRenderer cross;

    void Start()
    {
        instance = this;
        playerControllerM.PostFX();
    }

    public void ResetGame()
    {
        objs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        objs = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }

        Time.timeScale = 1f;
        playerControllerM.RecoverPostFX();
        cross.color = new Color(0f, 0.4705883f, 0.8431373f, 1f);
        playerControllerM.tr.position = Vector3.zero;
        playerControllerM.tr.rotation = Quaternion.identity;
        playerControllerM.rb.linearVelocity = Vector3.zero;
        playerControllerM.sr.enabled = true;
        playerControllerM.sr_s.enabled = true;
        playerControllerM.particles.SetActive(false);
        playerControllerM.RecoverPercentage();
        playerControllerM.hit = false;
        playerControllerM.EnableFx();
        pointControllerM.ChangePlace();
        enemySpawnerM.Restart();
        ScoreControllerM.instance.LoseScore();
    }

    public void StartGame()
    {
        state = 3;
    }
}