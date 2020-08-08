using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    float startPosX;
    float startPosY;
    public Vector2 mousePos;
    public bool beingDrag = false;

    private void Start()
    {
        print(Screen.height + " " + Screen.width);
        startPosX = transform.position.x;
        startPosY = transform.position.y;

    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (beingDrag)
        {
          transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseDown()
    {
        beingDrag = true;
    }

    private void OnMouseUp()
    {
        beingDrag = false;
    }
}
