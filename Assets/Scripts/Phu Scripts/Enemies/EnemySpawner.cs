using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemySpawnerManager spawnManager;

    private float spawnTimer;
    private bool cooldown;

    public GameObject enemyObject;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Timers") != null)
        {
            spawnManager = GameObject.Find("Timers").GetComponent<EnemySpawnerManager>();
        }

        //Set spawn rates
        spawnTimer = Random.Range(10f, 40f);
        cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnManager.noMoreSpawns == false)
        {
            spawnTimer -= Time.deltaTime;
        }

        //Spawn an enemy
        if (spawnTimer <= 0 && cooldown == false)
        {
            cooldown = true;
            spawnManager.AddSpawn();
            SpawnEnemy();
        }
    }

    //Spawn an enemy
    public void SpawnEnemy()
    {
        Instantiate(enemyObject, transform.position, Quaternion.identity);
        Invoke("Cooldown", 0.5f);
    }

    //Cooldown
    public void Cooldown()
    {
        spawnTimer = Random.Range(10f, 40f);
        cooldown = false;
    }
}
