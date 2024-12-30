using UnityEngine;
public class EnemySpawnerM : MonoBehaviour
{
    float frequency = 0.9f;
    public float timer;
    public GameObject enemy;
    GameObject obj;
    int r;
    bool first = true;
    Vector2 pos;
    float radius = 5.7f; //radio de spawn

    void Update()
    {
        if (GameControllerM.instance.state != 3) return;

        timer += Time.deltaTime;

        if (timer > frequency)
        {
            timer = 0;
            obj = Instantiate(enemy);
            pos = Random.insideUnitCircle.normalized * radius;
            obj.transform.position = new Vector2(pos.x, pos.y);
        }
    }

    public void Restart()
    {
        timer = frequency;
    }
}