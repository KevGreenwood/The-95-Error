using System.Collections.Generic;
using UnityEngine;
public class ColorControllerMenu : MonoBehaviour
{
    public static ColorControllerMenu instance;
    public Camera cam;
    List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    public Color[] colors;
    Color32 previousColor;
    public Color32 currentColor;
    Color32 nextColor;
    float timer = 10;
    public bool start;

    void Start()
    {
        instance = this;
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