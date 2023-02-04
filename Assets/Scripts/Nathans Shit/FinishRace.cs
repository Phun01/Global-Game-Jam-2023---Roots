using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRace : MonoBehaviour
{
    public PlayerMovement[] player;
    public PlayerMovement winningPlayer;
    public string winner;
    public int winnerNo;
    public bool finished;
    public float timer;
    public float time;
    public string countDown;

    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        for(int i = 0; i < player.Length; i++)
        {
            player[i].canMove = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(!start)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                countDown = "Ready!";
                Debug.Log(countDown);
            }
            if(timer >= 8)
            {
                countDown = "3!";
                Debug.Log(countDown);
            }
            if (timer >= 10)
            {
                countDown = "2!";
                Debug.Log(countDown);
            }
            if (timer >= 12)
            {
                countDown = "1!";
                Debug.Log(countDown);
            }
            if (timer >= 14)
            {
                countDown = "GO!";

                Debug.Log(countDown);
                for (int i = 0; i < player.Length; i++)
                {
                    player[i].canMove = true;
                }
                start = true;
            }
        }

        if(finished)
        {
            winner = "Player " + winnerNo + " Wins!!";
            Debug.Log(winner);
            Time.timeScale = 0f;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            finished = true;
            winnerNo = winningPlayer.GetComponent<PlayerMovement>().playerNo;
        }
    }
}
