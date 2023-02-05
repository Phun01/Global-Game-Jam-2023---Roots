using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civillian : MonoBehaviour
{
    private LevelManager levelManager;
    private CivillianManager civillianManager;

    public int civIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null)
        {
            levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        }
        if (GameObject.Find("Timers") != null)
        {
            civillianManager = GameObject.Find("Timers").GetComponent<CivillianManager>();
        }
    }

    //Save the civillian
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Add buffer time and score
            levelManager.totalScore += 1000;

            civillianManager.savedCivillians++;
            
            if(civillianManager.requiredCivillians > 0)
            {
                civillianManager.requiredCivillians -= 1;
            }

            civillianManager.AddBufferTime();
            civillianManager.DestroyCiv(civIndex);
            civillianManager.ReduceCivillians();
        }    
    }
}
