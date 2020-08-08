using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject img01;
    public GameObject img02;
    public GameObject txt01;
    public GameObject txt02;
    public GameObject allObjects;
    public GameObject canvasStuff;
    public GameObject tutorial;
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        allObjects.SetActive(false);
        canvasStuff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
          txt01.SetActive(false);
          txt02.SetActive(true);
          if(counter == 1)
          {
              img02.SetActive(true);
              img01.SetActive(false);
          }

          if(counter == 2)
          {
              allObjects.SetActive(true);
              canvasStuff.SetActive(true);
              tutorial.SetActive(false);
          }

          counter += 1;
        }
    }
}
