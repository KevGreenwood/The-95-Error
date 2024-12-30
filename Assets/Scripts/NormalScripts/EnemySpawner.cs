using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    float frequency = 0.9f;
    public float timer;
    float radius = 5.7f; // Spawn Ratio
    int r;
    bool first = true;
    public GameObject enemy;
    GameObject obj;
    Vector2 pos;

    void Update()
    {
        if (GameController.instance.state != 2) return;
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