using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public float attackLifetime;
    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = attackLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;

        if(attackTimer <= 0)
        {
            attackTimer = attackLifetime;
            gameObject.SetActive(false);
        }
    }

    //Deal damages
    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("col");

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject playerObject = collision.gameObject;

            playerObject.GetComponent<PlayerResources>().TakeDamage(1);
        }
    }
}
