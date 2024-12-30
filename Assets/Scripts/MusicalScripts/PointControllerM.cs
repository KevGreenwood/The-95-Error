using UnityEngine;
public class PointControllerM : MonoBehaviour
{
    public GameObject point;
    public Transform tr;
    public Transform playerTR;
    public PlayerControllerM playerControllerM;
    public SpriteRenderer sr_s;
    Vector3 pos;

    void Start()
    {
        ChangePlace();
    }
    void Update()
    {
        if (GameControllerM.instance.state == 4)
        {
            point.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerControllerM.RecoverPercentage();
            ScoreControllerM.instance.RaiseScore();
            ChangePlace();
        }
    }

    public void ChangePlace()
    {
        pos = Random.insideUnitCircle * 4f;
        while (Vector2.Distance(pos, playerTR.position) < 3.5f)
        {
            pos = Random.insideUnitCircle * 4f;
        }
        tr.position = pos;
    }
}