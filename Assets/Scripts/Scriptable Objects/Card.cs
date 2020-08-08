using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public int cardID;
    public string description;
    public string[] habilities;
    public Sprite targetIMG;
    public Sprite artwork;
    public string target;
    public Sprite template;
    public float damage;
    public string type;
    public string fxSound;
}
