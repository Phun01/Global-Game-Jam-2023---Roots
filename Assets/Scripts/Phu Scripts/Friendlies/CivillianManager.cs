using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CivillianManager : MonoBehaviour
{
    private LevelManager levelManager;

    private bool noMoreCivs;
    public int savedCivillians;
    private int numberOfCivillians;
    private List<GameObject> civilliansList;

    private float deathCountdown;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null)
        {
            levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        }

        numberOfCivillians = civilliansList.Count;

        noMoreCivs = false;
        deathCountdown = levelManager.civillianDeathTimer;
    }

    // Update is called once per frame
    void Update()
    {
        deathCountdown -= Time.deltaTime;

        //Random civillian dies
        if(deathCountdown <= 0 && noMoreCivs == false)
        {
            int i = Random.Range(0, civilliansList.Count);

            Destroy(civilliansList[i]);
            civilliansList.RemoveAt(i);

            ReduceCivillians();
            AddBufferTime();
        }
    }

    //Adds more buffer time
    public void AddBufferTime()
    {
        deathCountdown += levelManager.civillianDeathDelay;
    }

    //Removes a civillian and check Game Over
    public void ReduceCivillians()
    {
        numberOfCivillians--;

        //If number of civillians drops to 0
        if(numberOfCivillians <= 0)
        {
            noMoreCivs = true;

            //checks Game Over
            if(savedCivillians >= 4)
            {
                //You is winner
            }
            else
            {
                //Game Over stuff
            }
        }

    }

    //Adds civillians to list
    public void AddCivillian(GameObject civillian)
    {
        civilliansList.Add(civillian);
    }

    //Destroys civillians
    public void DestroyCiv(int index)
    {
        Destroy(civilliansList[index]);
        civilliansList.RemoveAt(index);
    }

    //Clears civillians from list
    public void ClearCivillians()
    {
        civilliansList = new List<GameObject>();
    }
}
