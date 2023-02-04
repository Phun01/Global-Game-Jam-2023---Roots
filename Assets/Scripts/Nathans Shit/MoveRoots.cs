using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveRoots : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject ground;

    public float timeMin;
    public float timeMax;

    public float waitTimer;
    public float waitTime;

    public bool stopped;
    public bool direction;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer > waitTime)
            {
                stopped = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if(!stopped)
        {
            waitTimer = 0;
            if (direction)
            {
                var step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, bottom.transform.position, step);
                GetComponent<BoxCollider>().isTrigger = true;
            }
            else
            {
                var step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, top.transform.position, step);
            }
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Bottom"))
        {
            waitTime = Random.Range(timeMin, timeMax);
            stopped = true;
            direction = false;
            top.GetComponent<BoxCollider>().enabled = true;
            bottom.GetComponent<BoxCollider>().enabled = false;
        }

        if (collision.gameObject.tag == ("Top"))
        {
            waitTime = Random.Range(timeMin, timeMax);
            stopped = true;
            direction = true;
            top.GetComponent<BoxCollider>().enabled = false;
            bottom.GetComponent<BoxCollider>().enabled = true;
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }

}
