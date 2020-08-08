using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCarta : MonoBehaviour
{
    public Image imagemSlot;
    public Card carta;

    public void AddItem(Card novaCarta)
    {
        //adiciona um item ao slot
        carta = novaCarta;
        imagemSlot.sprite = carta.template;       //mudar o icone
        imagemSlot.enabled = true;        //habilitar o icone
    }

    public void ClearSlot()
    {
        //limpa o slot
        carta = null;        //retira o conteudo do slot
        imagemSlot.sprite = null;     //retira o conteudo do icone
        imagemSlot.enabled = false;       //desabilita o icone
    }

    public void UsarItem()
    {
        //ao clickar no item no inventario
        if (carta != null)
        {
            Deck.instance.RemoverDeck(carta);
        }
    }
}
