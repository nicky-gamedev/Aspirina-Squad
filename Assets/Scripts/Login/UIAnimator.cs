using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimator : MonoBehaviour
{
    public Transform[] posicoesCamera;
    [Range(0,2)]
    public int posicaoAtual;
    public float tempo;
    public Vector3 velocidade;

    private void Start()
    {
        posicaoAtual = 1;
    }
    public void ToCadastro()
    {
        posicaoAtual= 0;
    }
    public void ToSelection()
    {
        posicaoAtual = 1;
    }
    public void ToLogin()
    {
        posicaoAtual = 2;
    }
    private void FixedUpdate()
    {
        MovimentoCamera();
    }
    public void MovimentoCamera()
    {
        Vector3 targetPosition = posicoesCamera[posicaoAtual].TransformPoint(Vector3.zero);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocidade, tempo);
    }
}
