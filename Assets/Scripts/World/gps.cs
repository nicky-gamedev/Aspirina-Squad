using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gps : MonoBehaviour
{
    public static float lat, lon;

    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        Input.location.Start();

        int tempo = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && tempo > 0)
        {
            yield return new WaitForSeconds(1);
            tempo--;
        }

        if (tempo < 1)
        {
            print("Tempo Excedido");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Falha");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("GPS Iniciado, Posição atual: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        lat = Input.location.lastData.latitude;
        lon = Input.location.lastData.longitude;
    }
}
