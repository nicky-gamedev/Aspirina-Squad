using UnityEngine;
﻿using UnityEngine.SceneManagement;

public class DeckBuild : MonoBehaviour
{
    public Card[] cartas;
    public ScrollerLock selectedCardID;

    public void AddCard()
    {
        Deck.instance.AdicionarDeck(cartas[selectedCardID.selectedID -1]);
        FindObjectOfType<AudioManager>().Play("Card Selected");
    }

    public void Quit()
    {
      SceneManager.LoadSceneAsync(1);
      SceneManager.UnloadSceneAsync(3);
      FindObjectOfType<AudioManager>().Play("Menu Shift");
    }
}
