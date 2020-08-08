using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentacao : MonoBehaviour {

    public float lat, lon;
    float vel = -5;

	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.anyKey)
        {
            if (Input.GetButton("Horizontal"))
            {
                lon = lon + (Input.GetAxisRaw("Horizontal") * vel);

            }
            if (Input.GetButton("Vertical"))
            {
                lat = lat + (Input.GetAxisRaw("Vertical") * vel);

            }

            transform.position = new Vector3(lon, 0.0f, lat);
        }

    }
}
