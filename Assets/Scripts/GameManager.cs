using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerScript player;
    public EnemyScript enemy;
    public int researchPoints;

    public static GameManager instance;

    void Awake()
    { //Define que o Game Manager será o mesmo em todas as cenas, substituindp os novos.
      if(instance == null)
      {
        instance = this;
      }
      else
      {
        Destroy(gameObject);
        return;
      }

      DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
      if(Input.GetMouseButtonDown(0))
      {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
          if(hitInfo.collider.CompareTag("Tree"))
          {
            SceneManager.LoadScene("Player Menu");
            FindObjectOfType<AudioManager>().Play("Card Selected");
          }
        }
      }
    }
}
