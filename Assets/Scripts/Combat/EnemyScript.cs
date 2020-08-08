using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Scrollbar lifeBar; //Barra de vida
    public float atkCounter = 3f; //Contador de ataque
    public bool isOkToMove, isOkToAttack; //Interruptor para controlar o movimento
    public float enemyPosX = 2.75f, enemyPosZ = 0f; //posição do inimigo em x
    public float damage; //Dano
    public PlayerScript player; //Referencia ao Jogador
    public Text warningText; //Texto de Aviso (Ataque)
    public GameObject battleUI; //UI de Batalha
    public GameObject victoryMenu; //Menu de Vitória
    public CameraShake cameraShake; //balanço da camera
    public GameObject subtratorInimigos; //subtração de inimigos do firebase.
    public Scrollbar chargeBar;

    public Animator anim;

    void Start()
    {
        damage = 0.2f;
        isOkToMove = true;
        isOkToAttack = true;
    }

    void Update()
    {
        transform.position = new Vector3(enemyPosX, 2.43f, enemyPosZ);
        lifeBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2f, 0));

        if (chargeBar.size != 0) //Checa se a booleana do player tá verdadeira
        {
            if (isOkToMove)
            {
                StartCoroutine(Move());
            }

            if (isOkToAttack)
            {
                StartCoroutine(Attack());
            }
        }

        if (lifeBar.size == 0) //Se barra de vida menor que zero:
        {
            battleUI.SetActive(false); //Desativar UI de batalha
            victoryMenu.SetActive(true); //Ativar menu de Vitória
            lifeBar.enabled = false; //Desativar Barra de Vida
            GameObject sub = Instantiate(subtratorInimigos);
            sub.transform.position = Vector3.zero;
            DontDestroyOnLoad(sub);
            Destroy(gameObject); //Destruir o objeto

        }
    }


    IEnumerator Attack() //Função Atacar
    {
        isOkToAttack = false; //Booleana de Controle

        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Surprise", false);
        anim.SetBool("Damage", false);
        anim.SetBool("Attack", true);
        warningText.enabled = true; //Ligar o texto de Aviso;
        damage = 0.2f; //Atualiza o dano

        yield return new WaitForSeconds(1.5f);
        player.lifeBar.size -= damage; //Barra de vida do jogador recebe dano
        warningText.enabled = false; //Desligar Texto de Aviso
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        FindObjectOfType<AudioManager>().Play("Enemy Hit");

        yield return new WaitForSeconds(.75f);
        anim.SetBool("Attack", false);
        isOkToAttack = true;
    }

    IEnumerator Move()
    {
        isOkToMove = false;
        yield return new WaitForSeconds(3f);

        //Bloco movimento X
        if (enemyPosX <= 1f)
        {
            print("saiu da esquerda");
            enemyPosX = 2.75f;
        }
        else if (enemyPosX >= 4.5)
        {
            print("saiu da direita");
            enemyPosX = 2.75f;
        }

        else if (enemyPosX == 2.75f)
        {
            int locationIntX = Random.Range(-1, 2);
            if (locationIntX == -1)
            {
                print("direita");
                enemyPosX = 1f;
            }

            else if (locationIntX == 0)
            {
                print("meio");
                enemyPosX = 2.75f;
            }

            else if (locationIntX == 1)
            {
                print("esquerda");
                enemyPosX = 4.5f;
            }
        }
        //Fim do bloco movimento X
        //Bloco de movimento y
        int locationIntZ = Random.Range(0, 2);
        if (locationIntZ == 0)
        {
            print("baixo");
            enemyPosZ = 0.0f;
        }
        else if (locationIntZ == 1)
        {
            print("cima");
            enemyPosZ = 2.74f;
        }

        isOkToMove = true;
    }
}
