using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogador : MonoBehaviour
{
    public float VelocidadeRotacao = 1; //Pode-se colocar como sensibilidade da camera tambem
    public Transform Base, Jogador, Objeto;  //Base é onde a camera vai se vincular, Jogador acho q n preciso explicar, Objeto é oq ficar na frente da camera
    float mouseX, mouseY;  //Posicao X e Y do mouse
    public float VelocidadeZoom = 2;  //Zoom que a camera faz quando um objeto entra na sua frente
    public bool UsandoMouse = true;
    void Start()
    {
        Objeto = Base;
        //Cursor.visible = false; //Desliga/liga o cursor
    }
    void LateUpdate()
    {
        ControleCamera();
        ObjetoFrenteCamera();
    }
    void Update()
    {
        
    }
    void ControleCamera()
    {
        if (UsandoMouse)
        {
            //Cursor.lockState = CursorLockMode.Locked; //Trava o cursor
            if (Input.GetMouseButton(0))
            {
                mouseX += Input.GetAxis("Mouse X") * VelocidadeRotacao;
                mouseY -= Input.GetAxis("Mouse Y") * VelocidadeRotacao;
            }

        }
        else
        {
            mouseX += Input.GetTouch(0).deltaPosition.x * VelocidadeRotacao;
            mouseY -= Input.GetTouch(0).deltaPosition.y * VelocidadeRotacao;
        }        
        mouseY = Mathf.Clamp(mouseY, -35, 60);  //Angulos limites para a rotação em Y, podemos mudar para quanto for melhor
        transform.LookAt(Base);  //Camera olha para a base dela
        Base.rotation = Quaternion.Euler(mouseY, mouseX, 0);  //rotação da camera através da sua base
        //Jogador.rotation = Quaternion.Euler(0, mouseX, 0);  //Rotação do personagem junto a camera (n sei se vamos querer ter isso, mas coloquei se precisar)
    }
    void ObjetoFrenteCamera()
    {
        RaycastHit hit;  //Raycast
        if(Physics.Raycast(transform.position, Base.position - transform.position, out hit, 8))  //O numero é a posição da camera
        {
            if(hit.collider.gameObject.tag != "Player")  //Checa se a tag é diferente de Player, se n tiver tag ele vai sumir e n vai voltar, então COLOCA TAG EM TUDO
            {
                Objeto = hit.transform;
                Objeto.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                if(Vector3.Distance(Objeto.position, transform.position) >= 3 && Vector3.Distance(transform.position, Base.position) >= 1.5f)  //Da zoom na camera pra parecer q ela foi atrapalhada pelo objeto
                {
                    transform.Translate(Vector3.forward * VelocidadeZoom * Time.deltaTime);
                }
            }
            else  //Volta o objeto ao seu estado de antes
            {
                Objeto.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if(Vector3.Distance(transform.position, Base.position) < 8)  //Tira o zoom para voltar ao normal (O numero é a posiçao da camera)
                {
                    transform.Translate(Vector3.back * VelocidadeZoom * Time.deltaTime);
                }
            }
        }
    }
}
