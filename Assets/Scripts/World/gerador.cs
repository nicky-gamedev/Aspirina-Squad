using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerador : MonoBehaviour
{
    bool infected = true;
    public float posX, posZ;
    public static int maxEnemy, enemyCount;
    public GameObject Enemy, Player, World;
    bool spawnControl;
    public Transform playerTarget;
    public float alturaSpawn;

    void Start()
    {
        maxEnemy = 20;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        spawnControl = true;
        FindObjectOfType<AudioManager>().Play("World Theme");
    }

    IEnumerator FabricaDeInimigos()
    {
        posX = (Player.transform.position.x*2) + Random.Range(playerTarget.position.x -100, playerTarget.position.x + 100);
        posZ = (Player.transform.position.z*2) + Random.Range(playerTarget.position.z - 100, playerTarget.position.z + 100);
        yield return new WaitForSeconds(5f);
        GameObject enemy = Instantiate(Enemy, new Vector3(posX, alturaSpawn, posZ),Quaternion.identity) as GameObject;
        enemy.transform.parent = World.transform;
        enemy.tag = "Enemy";
        enemyCount++;
        spawnControl = true;
    }


    void Update()
    {
        if (spawnControl && enemyCount <= maxEnemy)
        {
            StartCoroutine(FabricaDeInimigos());
            spawnControl = false;
        }
    }
}
