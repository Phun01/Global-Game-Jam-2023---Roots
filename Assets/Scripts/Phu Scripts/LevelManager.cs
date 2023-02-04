using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int player1Lives;
    public int player2Lives;

    public int totalScore;

    void Awake()
    {
        //Set default lives
        player1Lives = 3;
        player2Lives = 3;
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
