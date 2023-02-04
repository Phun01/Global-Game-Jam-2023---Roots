using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private LevelManager levelManager;

    public int enemyHealth;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();

        //Set enemy health
        enemyHealth = 4;
    }

    private void Update()
    {
        //Test damage on enemy
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Enemy took damage");
            TakeDamage();
        }
    }

    // Take damage/die & award score
    public void TakeDamage()
    {
        enemyHealth -= 1;

        //Destroy enemy and award score
        if (enemyHealth == 0)
        {
            levelManager.totalScore += 300;
            Destroy(gameObject);
        }
    }

}
