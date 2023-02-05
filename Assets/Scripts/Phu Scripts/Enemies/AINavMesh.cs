using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh : MonoBehaviour
{
    private Enemy enemyScript;
    private NavMeshAgent navMeshAgent;
    private LevelManager levelManager;

    private float speed;
    private bool chasingMode;

    public float attackRange;

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
        levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();

        //Sets the speed
        speed = GetComponent<Enemy>().moveSpeed;
        navMeshAgent.speed = speed;

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

        //Check distance
        float player1Distance = Vector3.Distance(levelManager.player1Object.transform.position, transform.position);
        float player2Distance = Vector3.Distance(levelManager.player2Object.transform.position, transform.position);

        //Compare distances of both players
        if (player1Distance < closestPlayer)
        {
            //Player 1 is target
            targetPlayer = levelManager.player1Object.transform;
            closestPlayer = player1Distance;
        }
        
        if (player2Distance < closestPlayer)
        {
            //Player 2 is target
            targetPlayer = levelManager.player2Object.transform;
            closestPlayer = player2Distance;
        }

        enemyScript.targetPlayer = targetPlayer.gameObject.GetComponent<PlayerResources>().playerNumber;
    }

    //Change player target
    public void ChangeTarget()
    {
        if (targetPlayer.gameObject == levelManager.player1Object.gameObject)
        {
            //Change to player 2
            targetPlayer = levelManager.player2Object.transform;
            enemyScript.targetPlayer = 2;
        }
        else
        {
            //Change to player 1
            targetPlayer = levelManager.player1Object.transform;
            enemyScript.targetPlayer = 1;
        }
    }

    //Enemy attack
    private void EnemyAttack()
    {
        //Set Cooldown
        cooldownTimer = attackSpeed;
        cooldownOn = true;

        //Stop chasing
        chasingMode = false;

        //Debug.Log("Tree Smack");

        //Perform the attack
        enemyScript.Attack();

        //Check nearest player
        FindNearestTarget();
    }
}
