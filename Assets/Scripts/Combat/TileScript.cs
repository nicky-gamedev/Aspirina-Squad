using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseOver()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
