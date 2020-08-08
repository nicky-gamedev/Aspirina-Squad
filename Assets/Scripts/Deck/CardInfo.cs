using UnityEngine;
﻿using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    public Card card;
    public Text nameTxt;
    public Image artworkImg;
    public Text descriptionTxt;
    public Image targetImg;
    public Text powerTxt;
    public ScrollerLock scrollerLock;
    // Start is called before the first frame update
    void Awake()
    {
        artworkImg.sprite = card.template;
    }

    void Update()
    {
      if(scrollerLock.selectedID == card.cardID)
      {
        nameTxt.text = card.name;
        descriptionTxt.text = card.description;
        targetImg.sprite = card.targetIMG;
        powerTxt.text = "Poder: " + card.damage.ToString();
      }
    }
}
