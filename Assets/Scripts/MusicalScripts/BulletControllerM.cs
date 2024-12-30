﻿using UnityEngine;
public class BulletControllerM : MonoBehaviour
{
    public Transform tr;
    float speed;
    public SpriteRenderer sr_s;

    void Start()
    {
        ColorControllerM.instance.AddSprite(sr_s);
        speed = 10f;
    }
    void Update()
    {
        tr.Translate(Vector2.up * speed * Time.deltaTime);

        if (tr.position.x > 6f || tr.position.x < -6f || tr.position.y > 6f || tr.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}