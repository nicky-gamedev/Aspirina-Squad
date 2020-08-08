using UnityEngine;
using UnityEngine.UI;

public class DrawingCards : MonoBehaviour
{
    public Scrollbar chargeBar;
    public GameObject newCard;
    public PlayerScript player;

    void Start()
    {
        Draw();
    }

    void Update()
    {
      if(chargeBar.size == 0)
      {
        Draw();
      }

      if(player.chargeDuration > 0 && transform.childCount == 0)
      {
        transform.SetParent(GameObject.Find("Card Select").transform);
      }
    }

    void Draw()
    {
      if (transform.childCount == 0 && transform.parent.name == "Card Select")
      {
        GameObject myCard = Instantiate(newCard, transform.position, transform.rotation) as GameObject;
        myCard.transform.SetParent(transform);
      }
    }
}
