using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private LevelManager levelManager;
    private HUDManager hudManager;
    public int playerNumber;

    public int playerHealth;
    public int playerLives;
    public int playerAmmo;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        levelManager.FindPlayers(); 

        hudManager = GameObject.Find("HUDManager").GetComponent<HUDManager>();

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

        //Kills player if lives is less than 0
        if(playerLives < 0)
        {
            Dead();
        }

        //Update player HUD
        hudManager.UpdatePlayerHUD(this);
    }

    // Update is called once per frame
    void Update()
    {
        /*Test Damage Player 1
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
        */
    }

    //Method to take damage
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        hudManager.UpdatePlayerHUD(this);

        //Die
        if (playerHealth <= 0)
        {
            playerLives -= 1;
            levelManager.LoseLife(playerNumber);

            //Set health back to 10
            playerHealth = 10;

            hudManager.UpdatePlayerHUD(this);
        }
    }

    //Method to use Ammo
    public void LoseAmmo()
    {
        if (playerAmmo >= 1)
        {
            playerAmmo -= 1;

            hudManager.UpdatePlayerHUD(this);
        }
        else
        {
            //No ammo
        }
    }

    //Method to kill the player
    public void Dead()
    {
        Destroy(gameObject);
    }

    //Method to recover Health with Health Pack
    public void ObtainHealthPack()
    {
        playerHealth = 10;
        levelManager.totalScore += 200;

        hudManager.UpdatePlayerHUD(this);
        hudManager.UpdateScore();
    }

    //Method to gain Ammo with Magazine
    public void ObtainMagazine()
    {
        playerAmmo += 20;
        levelManager.totalScore += 100;

        hudManager.UpdatePlayerHUD(this);
        hudManager.UpdateScore();
    }

}
