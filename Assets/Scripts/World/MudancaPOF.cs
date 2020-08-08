using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudancaPOF : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TempoEntreTrocas());
    }

    IEnumerator TempoEntreTrocas()
    {
        transform.localScale = new Vector3(5, 5, 5);
        yield return new WaitForSecondsRealtime(1);
        transform.localScale = new Vector3(2, 2, 2);
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(TempoEntreTrocas());
    }
}
