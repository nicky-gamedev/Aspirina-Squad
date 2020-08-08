using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverMensagemCadastro : MonoBehaviour
{
    public Transform lugarMensagem;
    public float tempoMov;
    public Vector3 velocidade;
    public bool iniciarMov;
    private void Awake()
    {
        lugarMensagem = GameObject.Find("TargetMensagem").transform;
        iniciarMov = true;
        StartCoroutine(destruirAposTempo(tempoMov));
    }
    private void FixedUpdate()
    {
        if (iniciarMov)
        {
            Vector3 targetPosition = lugarMensagem.TransformPoint(Vector3.zero);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocidade, tempoMov);
        }
    }
    IEnumerator destruirAposTempo(float t)
    {
        yield return new WaitForSeconds(t + 5);
        Destroy(gameObject);
    }
}
