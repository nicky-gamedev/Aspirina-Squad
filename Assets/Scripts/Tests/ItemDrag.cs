using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    Vector3 startPos;
    public static GameObject card;
    Transform parente;

    public void OnBeginDrag(PointerEventData eventData)
    {
        card = gameObject;
        startPos = transform.position;
        parente = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        card = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == parente)
        {
            transform.position = startPos;
        }
    }

    
}
