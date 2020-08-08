using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitiesExample : MonoBehaviour
{
    public Card card;

    void Update()
    {
      if(Input.GetKeyDown("space"))
      {
        for(int i = 1; i<= card.habilities.Length; i++)
        {
          Habilities(card.habilities[i]);
        }
      }
    }

    void Habilities(string keyWord)
    {
      if(keyWord == "Power Up")
      {
        print("Powered Up");
      }

      else if(keyWord == "Sword")
      {
        print("Cut");
      }

      else if(keyWord == "Shield")
      {
        print("Defense");
      }
    }
}
