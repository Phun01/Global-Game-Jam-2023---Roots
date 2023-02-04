using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private LevelManager levelManager;
    public int playerNumber;

    public int playerHealth;
    public int playerLives;
    public int playerAmmo;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();

        //Default health/ammo
        playerHealth = 10;
        playerAmmo = 40;

        //Sets player lives equal to value stored
        switch(playerNumber)
        {
            case 1:
                playerLives = levelManager.player1Lives; 
                break;

            case 2:
                playerLives = levelManager.player2Lives;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Test Damage Player 1
        if(Input.GetKeyDown(KeyCode.Z) & playerNumber == 1)
        {
            Debug.Log("Player 1 took damage");
            TakeDamage(1);
        }

        //Test Damage Player 2
        if (Input.GetKeyDown(KeyCode.X) & playerNumber == 2)
        {
            Debug.Log("Player 2 took damage");
            TakeDamage(1);
        }
    }

    //Method to take damage
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        //Die
        if(playerHealth <= 0)
        {
            playerLives -= 1;
            levelManager.LoseLife(playerNumber);

            //Set health back to 10
            playerHealth = 10;
        }
    }

    //Method to use Ammo
    public void LoseAmmo()
    {
        if (playerAmmo >= 1)
        {
            playerAmmo -= 1;
        }
        else
        {
            //No ammo
        }
    }

    //Method to recover Health with Health Pack
    public void ObtainHealthPack()
    {
        playerHealth = 10;
        levelManager.totalScore += 200;

        Debug.Log(levelManager.totalScore);
    }

    //Method to gain Ammo with Magazine
    public void ObtainMagazine()
    {
        playerAmmo += 20;
        levelManager.totalScore += 100;

        Debug.Log(levelManager.totalScore);
    }

}
