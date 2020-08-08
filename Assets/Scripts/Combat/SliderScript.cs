using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SliderScript : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public static Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = originalPos;
        print(originalPos);
    }
}
