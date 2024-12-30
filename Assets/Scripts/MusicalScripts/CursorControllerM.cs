using UnityEngine;
public class CursorControllerM : MonoBehaviour
{
    public Transform cursor;
    public SpriteRenderer sr_s;
    public Camera cam;

    void Start()
    {
        Cursor.visible = false;
        ColorControllerM.instance.AddSprite(sr_s);
    }
    void Update()
    {
        cursor.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }
}