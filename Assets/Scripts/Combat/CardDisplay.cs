using UnityEngine;
﻿using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public PlayerScript player; //Referencia ao jogador
    public int cardType; //Define, de 1 à 5, a habilidade do Card
    public Button thisButton; //O botão que representa o Card
    public Image cardColor; //referencia a imagem do card
    public Image powerCard;

    void Update()
    {
      if (cardType == 1) //Card de Ataque
      {
          cardColor.color = Color.red;
      }

      else if (cardType == 2) //Card Especial
      {
          cardColor.color = Color.blue;
      }

      else if (cardType == 3) //Card de Defesa
      {
          cardColor.color = Color.yellow;
      }

      else if (cardType == 4) //Card de PowerUp
      {
          cardColor.color = Color.magenta;
      }

      else if (cardType == 5) //Card de Cura
      {
          cardColor.color = Color.green;
      }

      if(cardType < 1 || cardType > 5)
      {
        cardType = Random.Range(1, 6);
      }
    }

    public void OnClick()
    {
      for(int i = 1; i<=5; i++)
      {
        powerCard = GameObject.Find("Power 0" + i).GetComponent<Image>();
        if(powerCard.enabled == false)
        {
          powerCard.enabled = true;
          powerCard.color = cardColor.color;
          break;
        }
      }
      player.chargeDuration -= 1; //Diminui o atributo de duração do jogador.
      thisButton.interactable = false; //O botão deixa de ser interativo.
    }
}
