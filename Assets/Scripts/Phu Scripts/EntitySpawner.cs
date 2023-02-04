using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    private LevelManager levelManager;
    private CivillianManager civManager;

    private List<GameObject> spawnPoints = new List<GameObject>();
    public int civillianSpawnCount;
    public int enemySpawnCount;

    public GameObject enemySpawnerObject;
    public GameObject civillianObject;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("GameManager") != null)
        {
            levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        }
        
        if(GameObject.Find("Timers") != null)
        {
            civManager = GameObject.Find("Timers").GetComponent<CivillianManager>();
        }

        //Clear civList
        civManager.ClearCivillians();

        //Find and add all spawns
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("EntitySpawns"));

        //Check there's the correct amount of spawnables
        if (spawnPoints.Count >= civillianSpawnCount + enemySpawnCount)
        {
            //Choose random index numbers from list
            List<GameObject> randomPoints1 = new List<GameObject>();
            List<GameObject> randomPoints2 = new List<GameObject>();

            int tempCount1 = 0;
            int tempCount2 = 0;

            for(int i = 0; i < spawnPoints.Count; i++)
            {
                float rng = Random.Range(0.0f, 1.0f);

                //Adds to enemy spawners
                if(rng < 0.5)
                {
                    if (enemySpawnCount > tempCount1)
                    {
                        tempCount1 += 1;
                        randomPoints1.Add(spawnPoints[i]);
                    }
                    else
                    {
                        randomPoints2.Add(spawnPoints[i]);
                    }   
                }

                //Adds to civillians
                if (rng > 0.5)
                {
                    if (civillianSpawnCount > tempCount2)
                    {
                        tempCount2 += 1;
                        randomPoints2.Add(spawnPoints[i]);
                    }
                    else
                    {
                        randomPoints1.Add(spawnPoints[i]);
                    }
                }
            }

            //Spawn Enemy Spawners
            foreach(GameObject randomPoint in randomPoints1)
            {
                Instantiate(enemySpawnerObject, randomPoint.transform.position, Quaternion.identity);
            }

            //Civillian Index
            int x = 0;
            //Spawn civillians
            foreach (GameObject randomPoint in randomPoints2)
            {
                GameObject civ = Instantiate(civillianObject, randomPoint.transform.position, Quaternion.identity);
                civ.GetComponent<Civillian>().civIndex = x;

                civManager.AddCivillian(civ);
                x++;
            }

        }
        else
        {
            Debug.Log("Add more spawnables to the map!");
        }
    }
}
