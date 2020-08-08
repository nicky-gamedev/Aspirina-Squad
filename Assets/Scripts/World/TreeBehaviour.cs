using System.Collections;
using UnityEngine;
﻿using UnityEngine.UI;

public class TreeBehaviour : MonoBehaviour
{
    public bool infected = false, control;
    float multiplyCounter;
    Vector3 pos;

    void Start()
    {
        control = true;
        Vector3 pos = transform.position;        
    }

    void Update()
    {
        if (control)
        {
            StartCoroutine(SlowUpdate());
        }
        
        if(infected && control)
        {
            StartCoroutine(Multiply());
        }
    }

    IEnumerator SlowUpdate()
    {
        control = false;
        yield return new WaitForSeconds(5f);
        int i = GameObject.FindGameObjectsWithTag("Enemy").Length;
        print(i);
        if(i >= 10)
        {
            infected = true;
            Debug.Log("Infectada!");
        }
        else
        {
            infected = false;
            Debug.Log("Segura!");
        }
        control = true;
    }

    IEnumerator Multiply()
    {
        yield return new WaitForSeconds(5f);
        gerador.maxEnemy++;
        Debug.Log("Maximo de inimigos na area aumentou para " + gerador.maxEnemy.ToString());
    }
}
