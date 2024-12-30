using UnityEngine;
public class CursorControllerMenu : MonoBehaviour
{
    public Transform cursor;
    public SpriteRenderer sr_s;
    public Camera cam;
    void Start()
    {
        Cursor.visible = false;
        ColorControllerMenu.instance.AddSprite(sr_s);
    }
    void Update()
    {
        cursor.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }
}