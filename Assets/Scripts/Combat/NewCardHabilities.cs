using UnityEngine;
﻿using UnityEngine.UI;

public class NewCardHabilities : MonoBehaviour
{
    public PlayerScript player;
    public EnemyScript enemy;
    public Text warning;
    public CameraShake cameraShake;
    public Animator enemyAnim;

    private void Start()
    {
        //Load
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyScript>();
        warning = GameObject.Find("Warning").GetComponent<Text>();
        enemyAnim = GameObject.Find("Enemy").GetComponent<Animator>();
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
    }

    public void CheckHabs(Card card, string parent)
    {
        for (int i = 0; i < card.habilities.Length; i++)
        {
            Habilities(card.habilities[i], card);
        }
        //print(card.target);
        Destroy(gameObject);
    }

    public void Habilities(string keyWord, Card card)
    {
        if (transform.parent.transform.parent.name == "Mão")
        {
            //Inicia as habs
            if (keyWord == "Power Up")
            {
                player.damage += card.damage/100;
                FindObjectOfType<AudioManager>().Play(card.fxSound);
            }

            else if (keyWord == "Damage")
            {
                enemy.lifeBar.size -= card.damage/100 + player.damage;
                enemyAnim.SetBool("Surprise", false);
                enemyAnim.SetBool("Attack", false);
                enemyAnim.SetBool("Damage", true);
                StartCoroutine(cameraShake.Shake(.15f, .3f));
                FindObjectOfType<AudioManager>().Play(card.fxSound);
                FindObjectOfType<AudioManager>().Play("Alien Hit");
                player.damage = 0;
            }

            else if (keyWord == "Defense")
            {
              if(warning.enabled == true)
              {
                enemy.damage = 0f;
                FindObjectOfType<AudioManager>().Play(card.fxSound);
                if(warning.enabled == false)
                {
                  enemy.damage = 0.2f;
                }
              }
            }

            else if (keyWord == "Heal")
            {
                player.lifeBar.size += card.damage/100;
                FindObjectOfType<AudioManager>().Play(card.fxSound);
            }
        }

    }
}
