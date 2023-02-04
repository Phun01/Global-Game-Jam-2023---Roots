using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    private LevelManager levelManager;

    public bool noMoreSpawns;
    private int totalEnemySpawned;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("GameManager") != null)
        {
            levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        }

        noMoreSpawns = false;
    }

    //Add
    public void AddSpawn()
    {
        totalEnemySpawned++;

        Debug.Log("There are " + totalEnemySpawned);

        if (totalEnemySpawned >= levelManager.totalEnemySpawns)
        {
            noMoreSpawns = true;
        }
    }
}
