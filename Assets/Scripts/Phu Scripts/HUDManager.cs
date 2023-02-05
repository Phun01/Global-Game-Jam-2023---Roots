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
    public GameObject player1Life1;
    public GameObject player1Life2;
    public GameObject player1Life3;
    public GameObject player1Ded;

    public Image player2Health;
    public GameObject player2Ammo;
    public GameObject player2Life1;
    public GameObject player2Life2;
    public GameObject player2Life3;
    public GameObject player2Ded;

    public GameObject totalScoreObject;

    public GameObject civilliansRemaining;
    public GameObject civilliansText;
    public GameObject extractionText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null)
        {
            levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        }

        UpdateScore();
    }

    public void UpdatePlayerHUD(PlayerResources player)
    {
        //Gets variables from player
        int playerNumber = player.playerNumber;
        float playerHealth = player.playerHealth;
        int playerLives = player.playerLives;
        int playerAmmo = player.playerAmmo;

        Debug.Log(playerLives);
        //Player 1 HUD update
        if(playerNumber == 1)
        {
            player1Health.fillAmount = playerHealth / 10;
            player1Ammo.GetComponent<TMP_Text>().text = playerAmmo.ToString();

            //lives
            switch (playerLives)
            {
                case 3:
                    break;

                case 2:
                    player1Life1.SetActive(false); 
                    break;

                case 1:
                    player1Life1.SetActive(false);
                    player1Life2.SetActive(false);
                    break;

                case 0:
                    player1Life1.SetActive(false);
                    player1Life2.SetActive(false);
                    player1Life3.SetActive(false);
                    break;

                case -1:
                    player1Ded.SetActive(true);
                    break;
            }
        }
        else //Player 2 HUD update
        {
            player2Health.fillAmount = playerHealth / 10;
            player2Ammo.GetComponent<TMP_Text>().text = playerAmmo.ToString();

            //lives
            switch (playerLives)
            {
                case 3:
                    break;

                case 2:
                    player2Life1.SetActive(false);
                    break;

                case 1:
                    player2Life1.SetActive(false);
                    player2Life2.SetActive(false);
                    break;

                case 0:
                    player2Life1.SetActive(false);
                    player2Life2.SetActive(false);
                    player2Life3.SetActive(false);
                    break;

                case -1:
                    player2Ded.SetActive(true);
                    break;
            }
        }
    }

    public void UpdateCivillianStats(CivillianManager cm)
    {
        if(cm.requiredCivillians > 0)
        {
            civilliansRemaining.SetActive(true);
            civilliansText.SetActive(true);
            civilliansRemaining.GetComponent<TMP_Text>().text = cm.requiredCivillians.ToString();
        }
        else
        {
            civilliansRemaining.SetActive(false);
            civilliansText.SetActive(false);
            extractionText.SetActive(true);
        }

    }

    public void UpdateScore()
    {
        totalScoreObject.GetComponent<TMP_Text>().text = levelManager.totalScore.ToString();
    }
}
