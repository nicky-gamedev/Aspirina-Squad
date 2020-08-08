using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerLock : MonoBehaviour
{
    //public Vector3[] locks;
    public Vector3 actualPos;
    public int selectedID;

    void Awake()
    {
      FindObjectOfType<AudioManager>().Play("Deck Theme");
    }

    public void GoDown()
    {
        transform.position += new Vector3(0,55f,0);
        if(selectedID < 30)
        {
          selectedID += 1;
            FindObjectOfType<AudioManager>().Play("Switch");
        }

    }
    public void GoUp()
    {
        transform.position -= new Vector3(0,55f,0);
        if(selectedID > 1)
        {
          selectedID -= 1;
          FindObjectOfType<AudioManager>().Play("Switch");
        }
    }
}
