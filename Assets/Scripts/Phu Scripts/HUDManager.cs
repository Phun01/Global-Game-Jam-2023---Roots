using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private LevelManager levelManager;

    //HUD gameobjects
    public Image player1Health;
    public GameObject player1Ammo;

    public Image player2Health;
    public GameObject player2Ammo;

    public GameObject totalScoreObject;
    public GameObject civilliansRemaining;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null)
        {
            levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        }
    }

    public void UpdatePlayerHUD(PlayerResources player)
    {
        //Gets variables from player
        int playerNumber = player.playerNumber;
        int playerHealth = player.playerHealth;
        int playerLives = player.playerLives;
        int playerAmmo = player.playerAmmo;

        //Player 1 HUD update
        if(playerNumber == 1)
        {
            player1Health.fillAmount = playerHealth / 10;
            player1Ammo.GetComponent<TMP_Text>().text = playerAmmo.ToString();
        }
        else //Player 2 HUD update
        {
            player2Health.fillAmount = playerHealth / 10;
            player2Ammo.GetComponent<TMP_Text>().text = playerAmmo.ToString();
        }

    }

    public void UpdateScore()
    {
        totalScoreObject.GetComponent<TMP_Text>().text = levelManager.totalScore.ToString();
    }
}
