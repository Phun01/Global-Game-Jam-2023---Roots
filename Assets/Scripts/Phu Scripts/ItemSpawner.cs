using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private List<GameObject> spawnPoints = new List<GameObject>();
    public int healthSpawnCount;
    public int magazineSpawnCount;

    public GameObject magazineObject;
    public GameObject healthObject;

    // Start is called before the first frame update
    void Start()
    {
        //Find and add all spawns
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("ItemSpawns"));

        //Check there's the correct amount of spawnables
        if (spawnPoints.Count >= healthSpawnCount + magazineSpawnCount)
        {
            //Choose random index numbers from list
            List<GameObject> randomPoints1 = new List<GameObject>();
            List<GameObject> randomPoints2 = new List<GameObject>();

            int tempCount1 = 0;
            int tempCount2 = 0;

            for(int i = 0; i < spawnPoints.Count; i++)
            {
                float rng = Random.Range(0.0f, 1.0f);

                //Adds to magazine
                if(rng < 0.5)
                {
                    if(magazineSpawnCount > tempCount1)
                    {
                        tempCount1 += 1;
                        randomPoints1.Add(spawnPoints[i]);
                    }
                    else
                    {
                        randomPoints2.Add(spawnPoints[i]);
                    }   
                }

                //Adds to healthpack
                if (rng > 0.5)
                {
                    if (healthSpawnCount > tempCount2)
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

            //Spawn magazine objects
            foreach(GameObject randomPoint in randomPoints1)
            {
                Instantiate(magazineObject, randomPoint.transform.position, Quaternion.identity);
            }

            //Spawn health packs
            foreach (GameObject randomPoint in randomPoints2)
            {
                Instantiate(healthObject, randomPoint.transform.position, Quaternion.identity);
            }

        }
        else
        {
            Debug.Log("Add more spawnables to the map!");
        }
    }
}
