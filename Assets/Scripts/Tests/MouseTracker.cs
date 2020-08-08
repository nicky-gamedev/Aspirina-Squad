using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    public static Vector2 Position;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Position = Input.mousePosition;
        Position = Camera.main.ScreenToWorldPoint(Position);

        print(Position);
    }
}
