using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject player1Object;
    public GameObject player2Object;

    public bool player1Dead;
    public bool player2Dead;

    public int player1Lives;
    public int player2Lives;

    public int totalScore;

    public int waveDifficulty;
    public float totalEnemySpawns;
    public float civillianDeathTimer;
    public float civillianDeathDelay;

    public GameObject fadeIn;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        player1Dead = false;
        player2Dead = false;

        ResetValues();
    }

    //Find players
    public void FindPlayers()
    {
        if (player1Object == null && player2Object == null)
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
            player1Dead = true;
        }

        if (player2Lives < 0)
        {
            player2Dead = true;
        }

        //Trigger Game Over
        if(player1Lives < 0 && player2Lives < 0)
        {
            GameOver();
        }    
    }

    //Reset Level
    public void ReloadLevel()
    {
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        totalScore += 2500;
        SceneManager.LoadScene(scene.name);
    }

    //Game Over
    public void GameOver()
    {
        LoadLevel(0);
        ResetValues();
        fadeIn.SetActive(true);
    }


    //Method to reset all values for a new game
    public void ResetValues()
    {
        //Sets the default lives
        player1Lives = 3;
        player2Lives = 3;

        //Sets the default wave 1 values
        waveDifficulty = 1;
        totalEnemySpawns = 20;
        civillianDeathTimer = 60;
        civillianDeathDelay = 40;

        //Sets score back to 0
        totalScore = 0;
    }

    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    //scene load
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        yield return new WaitForSeconds(2);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    }
}
