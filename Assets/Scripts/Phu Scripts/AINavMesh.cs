using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh : MonoBehaviour
{
    private Enemy enemyScript;
    private NavMeshAgent navMeshAgent;
    private float speed;
    private bool chasingMode;

    public float attackRange;

    private List<Transform> allPlayers = new List<Transform>();

    public Transform targetPlayer;
    private float distanceToPlayer;

    public float attackSpeed;
    private float cooldownTimer;
    private bool cooldownOn;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        //Sets the speed
        speed = GetComponent<Enemy>().moveSpeed;
        navMeshAgent.speed = speed;

        //Find all players and add to list
        List<GameObject> playerObject = new List<GameObject>();
        playerObject.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        foreach (GameObject x in playerObject)
        {
            allPlayers.Add(x.transform);
        }

        //Find default target
        FindNearestTarget();

        //Turn chasing mode on & attack cooldown off
        chasingMode = true;
        cooldownOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(targetPlayer.transform.position, transform.position);

        if(cooldownOn == true)
        {
            cooldownTimer -= Time.deltaTime;

            //Turn off cooldown and resume the chase
            if(cooldownTimer <= 0 )
            {
                chasingMode = true;
                cooldownOn = false;
            }
        }

        //Chase nearest target
        if(chasingMode == true)
        {
            navMeshAgent.destination = targetPlayer.position;
        }

        //Check if enemy is in attack range
        if(distanceToPlayer <= attackRange && cooldownOn == false)
        {
            //Perform attack
            EnemyAttack();
        }

        /*Test move to target
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Find nearest target
            FindNearestTarget();

            navMeshAgent.destination = targetPlayer.position;
        }
        */
    }

    //Method to find nearest target
    private void FindNearestTarget()
    {
        //Distance from closest player
        float closestPlayer;

        if(targetPlayer == null)
        {
            //Default
            closestPlayer = 999;
        }
        else
        {
            closestPlayer = Vector3.Distance(targetPlayer.transform.position, transform.position);
        }

        foreach(Transform t in allPlayers)
        {
            float distance;

            distance = Vector3.Distance(t.position, transform.position);

            Debug.Log(t + " " + distance);

            //Compare distance
            if(distance < closestPlayer)
            {
                //Change target player
                closestPlayer = distance;
                targetPlayer = t;
            }
        }
    }

    //Change player target
    private void ChangeTarget(int playerNumber)
    {
        playerNumber -= 1;

        targetPlayer = allPlayers[playerNumber];
    }

    //Enemy attack
    private void EnemyAttack()
    {
        //Set Cooldown
        cooldownTimer = attackSpeed;
        cooldownOn = true;

        //Stop chasing
        chasingMode = false;

        Debug.Log("Tree Smack");

        //Perform the attack
        enemyScript.Attack();

        //Check nearest player
        FindNearestTarget();
    }
}
