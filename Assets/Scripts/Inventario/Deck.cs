using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    #region instanciaDeck

    public static Deck instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Mais de uma instancia, algo está muito errado");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int espaco = 30;

    public List<Card> cartasDeck = new List<Card>();

    public bool AdicionarDeck(Card carta)
    {
        if (cartasDeck.Count >= espaco)
        {
            Debug.Log("Sem espaco no inventario");
            return false;
        }
        cartasDeck.Add(carta);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }
    public void RemoverDeck(Card carta)
    {
        cartasDeck.Remove(carta);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
