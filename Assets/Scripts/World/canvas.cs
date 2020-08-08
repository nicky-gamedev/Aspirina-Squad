using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvas : MonoBehaviour
{
    public Scrollbar worldLifebar;
    public static float worldLifeBarStatus;

    void Awake()
    {
      FindObjectOfType<AudioManager>().Play("World Theme");
    }

    void Start()
    {
        worldLifebar.size = 1f;
    }

    void Update()
    {
        worldLifeBarStatus = worldLifebar.size;
        worldLifebar.size = PlayerScript.lifebarSizeinCombat;
    }
}
