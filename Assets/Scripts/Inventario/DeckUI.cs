using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUI : MonoBehaviour
{
    public Transform parenteItens;
    Deck deck;
    SlotCarta[] slots;
    void Start()
    {
        deck = Deck.instance;
        deck.onItemChangedCallback += UpdateUI;
        slots = parenteItens.GetComponentsInChildren<SlotCarta>();
    }

    void UpdateUI()
    {
        Debug.Log("Update UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < deck.cartasDeck.Count)
            {
                slots[i].AddItem(deck.cartasDeck[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
