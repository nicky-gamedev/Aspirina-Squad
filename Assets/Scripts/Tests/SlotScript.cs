using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDropHandler
{
    public GameObject espacolivre
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    } 

    public void OnDrop(PointerEventData eventData)
    {
        if (!espacolivre)
        {
            ItemDrag.card.transform.SetParent(transform);
        }
    }
}
