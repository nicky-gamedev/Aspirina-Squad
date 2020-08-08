using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDisplayer : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler
{
    string parente; //Gravar o nome do parente da carta
    Vector3 originalPos; //Posição original, para o drag
    //Itens da UI da carta
    public Card card;

    public Text nameText;
    public Text damageText;

    public Image cardColor;
    public Image template;
    public Image targetIMG;

    public string target;
    //Referencias de classe
    public PlayerScript player;

    public Material originalEnemyMat;
    public Material enemyMat;
    public Material enemyOutline;

    public Material myOutline;

    public NewCardHabilities habilities;

    public static bool draggingCard;
    public bool selected = false;
    public int oldIndex;

    public GameObject cardSelect;

    void Start()
    {
        //Load de Referencias
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        cardSelect = GameObject.Find("Card Select");
        habilities = GetComponent<NewCardHabilities>();
        card = Resources.Load<Card>(Random.Range(1, 6).ToString());
        //Carregando UI
        nameText.text = card.name;
        template.sprite = card.template;
        cardColor.sprite = card.artwork;
        targetIMG.sprite = card.targetIMG;
        damageText.text = card.damage.ToString();
        //Guardando as variaveis
        parente = transform.parent.name;
        print(parente);
        originalPos = transform.position;

          if(parente == "Card Spawn " + 2 || parente == "Card Spawn " + 5)
          {
            transform.Rotate(new Vector3(0f, 0f, -15f));
          }

          else if(parente == "Card Spawn " + 1 || parente == "Card Spawn " + 3)
          {
            transform.Rotate(new Vector3(0f, 0f, 15f));
          }

          oldIndex = transform.GetSiblingIndex();
    }

    void Update()
    {
      if(player.chargeDuration <= 0 && !selected)
      {
          cardSelect.SetActive(false);
      }
    }

    //função de click do Event System
    public void OnPointerClick(PointerEventData eventData)
    {
        //Se o nome do parente for igual ao primeiro, roda
        if(transform.parent.name == parente)
        {
            //Qualquer efeito sobre a carta selecionada vai aqui, no caso, sobe pra mão
            //Sobe a carta

            if(player.chargeDuration > 0)
            {
              if(!selected)
              {
                int newIndex = GameObject.Find(parente).transform.GetSiblingIndex();
                GameObject.Find(parente).transform.SetSiblingIndex(newIndex -= 5);
                selected = true;
                player.chargeDuration--;
                transform.parent.transform.SetParent(GameObject.Find("Mão").transform);
                template.material = myOutline;
                FindObjectOfType<AudioManager>().Play("Switch");
                //Transforma ela parente do objeto Mão
              }

              else
              {
                GameObject.Find(parente).transform.SetSiblingIndex(oldIndex);
                selected = false;
                player.chargeDuration++;
                transform.parent.transform.SetParent(GameObject.Find("Card Select").transform);
                template.material = null;
                FindObjectOfType<AudioManager>().Play("Shift");
              }
            }
            //Atualiza a posição
            originalPos = transform.position;
        }
    }

    //Drag and Drop.
    public void OnDrag(PointerEventData eventData)
    {
        if(transform.parent.transform.parent.name == "Mão" && player.chargeDuration == 0)
        {
            transform.position = Input.mousePosition;
            draggingCard = true;

            if(card.target == "Enemy")
            {
              enemyMat = GameObject.Find("Enemy").GetComponent<Material>();
              enemyMat = enemyOutline;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      if(transform.parent.transform.parent.name == "Mão" && player.chargeDuration == 0)
      {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            print(hitInfo.collider.gameObject.name);
              if(hitInfo.collider.gameObject.name == card.target)
              {
                  habilities.CheckHabs(card, parente);
                  enemyMat = originalEnemyMat;
              }
              else
              {
                Destroy(gameObject);
              }
        }
      }
    }
}
