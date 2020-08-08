using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clicker : MonoBehaviour
{
    public Text contador;
    public Text mensagem;
    public GameObject inimigo, incrementadorInimigos, player, mundo, cenaAtual, cenaMundo;
    public int conta;
    public bool clickerOn;
    void Start()
    {
        clickerOn = true;
    }


    IEnumerator clickerMain()
    {
        yield return new WaitForSeconds(10.0f);
        clickerOn = false;
        mensagem.text = "Seu monstro foi solto no mundo!";
        yield return new WaitForSeconds(1.0f);
        cenaAtual.SetActive(false);
        cenaMundo.SetActive(true);
        float posX = player.transform.localPosition.x;
        float posZ = player.transform.localPosition.z;
        GameObject adicao = Instantiate(incrementadorInimigos);
        adicao.transform.position = Vector3.zero;
        DontDestroyOnLoad(adicao);
    }
    

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0) && clickerOn)
            {
                StartCoroutine(clickerMain());
                conta++;
                inimigo.transform.localScale = new Vector3(5.0f + conta, 5.0f + conta, 5.0f + conta);
            }
        }

        contador.text = conta.ToString();
    }
}
