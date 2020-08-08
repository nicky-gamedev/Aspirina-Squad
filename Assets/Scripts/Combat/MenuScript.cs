using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerScript player;
    public Button thisButton;
    public Text bonusText;

    void Start()
    {
      FindObjectOfType<AudioManager>().Play("Battle Theme");
      gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
      bonusText.enabled = false;
    }

    void Update()
    {
      float bonus = player.damage*100;
      bonusText.text = "+ " + bonus.ToString();

      if(player.damage > 0)
      {
        bonusText.enabled = true;
      }

      else
      {
        bonusText.enabled = false;
      }
    }

    public void Reward()
    {
      gameManager.researchPoints += Random.Range(10, 50);
      print(gameManager.researchPoints);
      thisButton.interactable = false;
      FindObjectOfType<AudioManager>().Play("Card Selected");
    }

    public void BackBtn()
    {
      SceneManager.LoadSceneAsync(1);
      SceneManager.UnloadSceneAsync(2);
      FindObjectOfType<AudioManager>().Play("Switch");
    }
}
