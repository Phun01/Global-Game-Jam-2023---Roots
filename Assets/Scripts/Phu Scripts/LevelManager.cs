using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player1Object;
    public GameObject player2Object;

    public int player1Lives;
    public int player2Lives;

    public int totalScore;

    public float totalEnemySpawns;
    public float civillianDeathTimer;
    public float civillianDeathDelay;

    void Awake()
    {
        //Set default lives
        player1Lives = 3;
        player2Lives = 3;
    }

    //Find players
    public void FindPlayers()
    {
        if(player1Object == null && player2Object == null)
        {
            //Find all players and add to list
            List<GameObject> playerObject = new List<GameObject>();
            playerObject.AddRange(GameObject.FindGameObjectsWithTag("Player"));
            foreach (GameObject x in playerObject)
            {
                if (x.GetComponent<PlayerResources>().playerNumber == 1)
                {
                    player1Object = x;
                }

                if (x.GetComponent<PlayerResources>().playerNumber == 2)
                {
                    player2Object = x;
                }
            }
        }    
    }

    //Subtracts and saves life
    public void LoseLife(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                player1Lives -= 1;
                break;

            case 2:
                player2Lives -= 1;
                break;
        }

        //Game Over
        if(player1Lives < 0)
        {
            Debug.Log("Player 1 ded");
        }

        if (player2Lives < 0)
        {
            Debug.Log("Player 2 ded");
        }
    }
}
