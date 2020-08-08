using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciar : MonoBehaviour
{
    void Start()
    {
      FindObjectOfType<AudioManager>().Play("Menu Theme");
    }

    public void Login()
    {
        FindObjectOfType<AudioManager>().Play("Start");
        SceneManager.LoadScene("Mapa");
    }
}
