using UnityEngine;
﻿using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyInteraction : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
      StartCoroutine(Animate());
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
              StartCoroutine(ChangeScene());
        }
    }

    IEnumerator Animate()
    {
      int randomize = Random.Range(0, 10);
      if(randomize <= 7)
      {
        anim.SetBool("Surprise", false);
        anim.SetBool("Idle", true);
      }
      else
      {
        anim.SetBool("Idle", false);
        anim.SetBool("Surprise", true);
      }

      yield return new WaitForSeconds(1f);

      StartCoroutine(Animate());
    }

    IEnumerator ChangeScene()
    {
      FindObjectOfType<AudioManager>().Play("Alien");
      yield return new WaitForSeconds(1f);
      if(SceneManager.GetActiveScene().name == "Mapa")
      {
        SceneManager.LoadScene("Combat");
      }
    }
}
