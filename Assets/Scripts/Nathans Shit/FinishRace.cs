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

    //Evan's things
    public GameObject readyTxt;
    public GameObject num3;
    public GameObject num2;
    public GameObject num1;
    public GameObject goTxt;

    public GameObject winLeft;

    public GameObject winRight;

    //sounds
    public AudioSource goSound;
    public AudioSource chuggaChug;

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
            timer -= Time.deltaTime;        

        WinSeq();
        TimerSeq();


        if(finished)
        {
            winner = "Player " + winnerNo + " Wins!!";
            Debug.Log(winner);
            Time.timeScale = 0f;
        }       
    }

public void WinSeq()
{
    if(winnerNo == 1)
        {
            winLeft.SetActive(true);
        }

        if(winnerNo == 2)
        {
            winRight.SetActive(true);
        }
}

public void TimerSeq()
{
    if (timer <= 10)
            {
                countDown = "Ready!";
                Debug.Log(countDown);
            }
            if(timer <= 8)
            {
                num3.SetActive(true);
                countDown = "3!";
                Debug.Log(countDown);
            }
            if (timer <= 6)
            {
                num3.SetActive(false);
                num2.SetActive(true);
                countDown = "2!";
                Debug.Log(countDown);
            }
            if (timer <= 4)
            {
                num2.SetActive(false);
                num1.SetActive(true);
                countDown = "1!";
                Debug.Log(countDown);                
            }
            if (timer <= 2)
            {
                chuggaChug.Play();
                goSound.Play();
                num1.SetActive(false);
                readyTxt.SetActive(false);
                goTxt.SetActive(true);
                //playsound
                countDown = "GO!";

                Debug.Log(countDown);
                player [1].canMove = true;
                player [2].canMove = true;
                
            }

            if (timer <= 0)
            {
                goTxt.SetActive(false);
                timer = 15;
            }

            if (timer >= 14)
            {
                timer =15;
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
