using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorControllerM : MonoBehaviour
{
    public static ColorControllerM instance;
    public Camera cam;
    public PlayerControllerM playerControllerM;
    public SpriteRenderer offscreen;
    public SpriteRenderer offscreen_s;
    public SpriteRenderer boundary;
    public SpriteRenderer boundary_s;
    public TMP_Text percentage;
    List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    public Color[] colors;
    Color32 previousColor;
    public Color32 currentColor;
    Color32 nextColor;
    float timer = 10;
    int alpha;
    public bool start;

    void Start()
    {
        instance = this;
        sprites.Add(offscreen);
        sprites.Add(offscreen_s);
        sprites.Add(boundary);
        sprites.Add(boundary_s);
        previousColor = cam.backgroundColor;
        nextColor = cam.backgroundColor;
        timer = 30;
    }
    void Update()
    {
        if (!start) return;
        if (timer >= 30)
        {
            timer = 0;
            PickNewColor();
        }

        timer += Time.deltaTime;

        currentColor = Color32.Lerp(previousColor, nextColor, timer / 30f);

        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i] != null)
            {
                sprites[i].color = currentColor;
            }
            else
            {
                sprites.RemoveAt(i);
                i--;
            }
        }
        cam.backgroundColor = currentColor;

        if (playerControllerM.percentage > 95) // UI Alpha
        {
            alpha = 75 + (210 - (playerControllerM.percentage * 2));
        }
        else
        {
            alpha = 110 + (210 - (playerControllerM.percentage * 2));
        }
        if (alpha > 255) alpha = 255;
        currentColor.a = (byte)alpha;
        percentage.color = currentColor;

        alpha = 20 + (ScoreControllerM.instance.score * 10);
        if (alpha > 255) alpha = 255;
        currentColor.a = (byte)alpha;
    }

    void PickNewColor()
    {
        previousColor = nextColor;
        while (nextColor.Equals(previousColor))
        {
            nextColor = colors[Random.Range(0, colors.Length)];
        }
    }

    public void AddSprite(SpriteRenderer sr)
    {
        sprites.Add(sr);
    }
}