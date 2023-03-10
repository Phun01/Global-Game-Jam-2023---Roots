using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CivillianManager : MonoBehaviour
{
    private LevelManager levelManager;
    private HUDManager hudManager;

    public GameObject extractionPoint;
    private bool noMoreCivs;
    public int requiredCivillians;
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

        hudManager = GameObject.Find("HUDManager").GetComponent<HUDManager>();

        requiredCivillians = 4;
        hudManager.UpdateCivillianStats(this);

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

            if(civilliansList[i] == null)
            {
                int temp = CheckCivillians();

                i = temp;
            }

            Destroy(civilliansList[i]);

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

        hudManager.UpdateCivillianStats(this);

        //If number of civillians drops to 0
        if (numberOfCivillians <= 0)
        {
            noMoreCivs = true;

            //checks Game Over
            if(savedCivillians >= 4)
            {
                //You is winner
                levelManager.ReloadLevel();
            }
            else
            {
                //Game Over stuff
                levelManager.GameOver();
            }
        }

    }

    //Adds civillians to list
    public void AddCivillian(GameObject civillian)
    {
        civilliansList.Add(civillian);
        numberOfCivillians = civilliansList.Count;
    }

    //Turn on Extraction
    public void Extraction()
    {
        extractionPoint.SetActive(true);
    }


    //Check for valid civillians
    public int CheckCivillians()
    {
        for(int i = 0; i < civilliansList.Count; i++)
        {
            if (civilliansList[i] != null)
            {
                return i;
            }
        }

        //None found
        return 0;
    }

    //Destroys civillians
    public void DestroyCiv(int index)
    {
        Destroy(civilliansList[index]);
    }

    //Clears civillians from list
    public void ClearCivillians()
    {
        civilliansList = new List<GameObject>();
    }
}
