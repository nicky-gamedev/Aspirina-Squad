using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject MenuPausaUI, RestoUI;
    //MenuPausaUI - Empty com tudo que aparece no pause
    //RestoUI - Empty com toda ui que vai desaparecer quando pausar
    private void Start()
    {
        MenuPausaUI.SetActive(false);
        RestoUI.SetActive(true);
    }

    public void BotaoPause()
    {
        MenuPausaUI.SetActive(true);
        RestoUI.SetActive(false);
    }
    public void BotaoResume()
    {
        MenuPausaUI.SetActive(false);
        RestoUI.SetActive(true);
    }
    public void BotaoMenu()
    {
        SceneManager.LoadScene("Tela Inicial");
    }
    public void BotaoQuit()
    {
        Application.Quit();
    }
}
