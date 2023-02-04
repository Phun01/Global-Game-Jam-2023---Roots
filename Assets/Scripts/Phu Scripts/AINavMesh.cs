using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private float speed;

    private List<Transform> allPlayers = new List<Transform>();
    public Transform targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
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

        Debug.Log(allPlayers.Count);
    }

    // Update is called once per frame
    void Update()
    {

        //Test move to target
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Find nearest target
            FindNearestTarget();

            navMeshAgent.destination = targetPlayer.position;
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
}
