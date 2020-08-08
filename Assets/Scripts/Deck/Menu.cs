using UnityEngine;
﻿using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button btn01;
    public Button btn02;
    public Button btn03;
    public bool menuOn = false;

    public void Pressed()
    {
      if(!menuOn)
      {
        btn01.transform.position = new Vector2(-2.3f,50);
        btn02.transform.position = new Vector2(-230,40);
        btn03.transform.position = new Vector2(-250,30);
        menuOn = true;
      }

      else if(menuOn)
      {
        btn01.transform.position = transform.position;
        btn02.transform.position = transform.position;
        btn03.transform.position = transform.position;
        menuOn = false;
      }
    }
}
