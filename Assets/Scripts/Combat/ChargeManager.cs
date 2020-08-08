using UnityEngine;
﻿using UnityEngine.UI;

public class ChargeManager : MonoBehaviour
{
    public GameObject charge;
    public Scrollbar chargeBar;
    public GameObject cardSelect;
    public PlayerScript player;
    public Text durationText;
    public Animator enemyAnim;

    void Start()
    {
      chargeBar.size = 0f;
      enemyAnim = GameObject.Find("Enemy").GetComponent<Animator>();
    }

    void Update()
    {
      durationText.text = player.chargeDuration.ToString();
      if(chargeBar.size >= 1)
      {
        enemyAnim.SetBool("Damage", false);
        enemyAnim.SetBool("Attack", false);
        enemyAnim.SetBool("Surprise", true);
        FindObjectOfType<AudioManager>().Play("Ready");
        player.chargeDuration += 2;
        cardSelect.SetActive(true);
        chargeBar.size = 0f;
        charge.SetActive(false);
      }

      if(player.chargeDuration <= 0)
      {
        charge.SetActive(true);
        chargeBar.size += Time.deltaTime/5;
      }
    }
}
