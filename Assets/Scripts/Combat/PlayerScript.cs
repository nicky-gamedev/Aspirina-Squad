using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Scrollbar lifeBar;
    public int chargeDuration = 0;
    public float rechargeTime = 0.5f;
    /*
    Habilidade:
    Resistencia:
    Energia:
    Cargas:
    */
    public EnemyScript enemy;
    public float damage = 0.3f;
    public GameObject battleUI;
    public GameObject defeatMenu;
    public static float lifebarSizeinCombat;

    void Start()
    {
        lifeBar.size = 1f;
    }

    void Update()
    {
        lifebarSizeinCombat = lifeBar.size;
        if (lifeBar.size <= 0)
        {
            battleUI.SetActive(false);
            defeatMenu.SetActive(true);
        }

        //Booleana de controle do turno, detecta se o player usou todas as cargas
        //Atualmente usando no controle do movimento do inimigo. Apenas.
    }
}
