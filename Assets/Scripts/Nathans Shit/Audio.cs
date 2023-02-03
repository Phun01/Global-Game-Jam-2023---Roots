using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("Tencion")]
    public int tenceNo;
    public AudioSource drums;
    public AudioSource piano;
    public float rollUpSpeed;
    public float coolOffTime;
    float coolOffTimer;
    bool coolOff;

    [Header("Player")]
    public AudioSource[] footSteps;
    int footStepNo;
    bool footStepExists;

    public AudioSource[] pistol;
    int pistolNo;
    bool pistolExists;

    public AudioSource[] ricoshate;
    int ricoshateNo;
    bool ricoshateExists;

    public AudioSource[] playerHey;
    int playerHeyNo;
    bool playerHeyExists;

    public AudioSource[] playerHurt;
    int playerHurtNo;
    bool playerHurtExists;

    public AudioSource[] playerCelebrate;
    int playerCelebrateNo;
    bool playerCelebrateExists;

    [Header("Enemy")]
    public AudioSource[] enemyHurt;
    int enemyHurtNo;
    bool enemyHurtExists;

    public AudioSource[] enemyAttack;
    int enemyAttackNo;
    bool enemyAttackExists;

    public AudioSource[] enemyDie;
    int enemyDieNo;
    bool enemyDieExists;

    public AudioSource[] enemyCharge;
    int enemyChargeNo;
    bool enemyChargeExists;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tenceNo == 1 && piano.volume < 1)
        {
            coolOff = true;
            piano.volume += Time.deltaTime * rollUpSpeed;
        }
        else if (tenceNo != 1 && piano.volume > 0)
        {
            piano.volume -= Time.deltaTime * rollUpSpeed;
        }

        if(tenceNo == 2 && drums.volume <= 1)
        {
            drums.volume += Time.deltaTime * rollUpSpeed;
        }
        else if (tenceNo != 2 && drums.volume > 0)
        {
            drums.volume -= Time.deltaTime * rollUpSpeed;
        }

        if(tenceNo == 1 && coolOff)
        {
            coolOffTimer += Time.deltaTime;
            if(coolOffTimer >= coolOffTime)
            {
                tenceNo = 0;
                coolOffTimer = 0;
                coolOff = false;
            }
        }
    }

    public void Pistol()
    {
        if (pistol.Length <= 0)
        {
            pistolExists = false;
        }
        else
        {
            pistolExists = true;
        }
        if (pistolExists)
        {
            pistolNo = Random.Range(0, pistol.Length);
            pistol[pistolNo].Play();
        }
    }

    public void FootSteps ()
    {
        if (footSteps.Length <= 0)
        {
            footStepExists = false;
        }
        else
        {
            footStepExists = true;
        }
        if (footStepExists)
        {
            footStepNo = Random.Range(0, footSteps.Length);
            footSteps[footStepNo].Play();
        }
    }

    public void Ricoshate()
    {
        if (ricoshate.Length <= 0)
        {
            ricoshateExists = false;
        }
        else
        {
            ricoshateExists = true;
        }
        if (ricoshateExists)
        {
            ricoshateNo = Random.Range(0, ricoshate.Length);
            ricoshate[ricoshateNo].Play();
        }
    }

    public void EnemyHurt()
    {
        if (enemyHurt.Length <= 0)
        {
            enemyHurtExists = false;
        }
        else
        {
            enemyHurtExists = true;
        }
        if (enemyHurtExists)
        {
            enemyHurtNo = Random.Range(0, enemyHurt.Length);
            enemyHurt[enemyHurtNo].Play();
        }
    }

    public void EnemyAttack()
    {
        if (enemyAttack.Length <= 0)
        {
            enemyAttackExists = false;
        }
        else
        {
            enemyAttackExists = true;
        }
        if (enemyAttackExists)
        {
            enemyAttackNo = Random.Range(0, enemyAttack.Length);
            enemyAttack[enemyAttackNo].Play();
        }
    }
    public void EnemyDie()
    {
        if (enemyDie.Length <= 0)
        {
            enemyDieExists = false;
        }
        else
        {
            enemyDieExists = true;
        }
        if (enemyDieExists)
        {
            enemyDieNo = Random.Range(0, enemyDie.Length);
            enemyDie[enemyDieNo].Play();
        }
    }

    public void EnemyCharge()
    {
        if (enemyCharge.Length <= 0)
        {
            enemyChargeExists = false;
        }
        else
        {
            enemyChargeExists = true;
        }
        if (enemyChargeExists)
        {
            enemyChargeNo = Random.Range(0, enemyCharge.Length);
            enemyCharge[enemyChargeNo].Play();
        }
    }

    public void PlayerHey()
    {
        if (playerHey.Length <= 0)
        {
            playerHeyExists = false;
        }
        else
        {
            playerHeyExists = true;
        }
        if (playerHeyExists)
        {
            playerHeyNo = Random.Range(0, playerHey.Length);
            playerHey[playerHeyNo].Play();
        }
    }
    public void PlayerHurt()
    {
        if (playerHurt.Length <= 0)
        {
            playerHurtExists = false;
        }
        else
        {
            playerHurtExists = true;
        }
        if (playerHurtExists)
        {
            playerHurtNo = Random.Range(0, playerHurt.Length);
            playerHurt[playerHurtNo].Play();
        }
    }

    public void PlayerCelebrate()
    {
        if (playerCelebrate.Length <= 0)
        {
            playerCelebrateExists = false;
        }
        else
        {
            playerCelebrateExists = true;
        }
        if (playerCelebrateExists)
        {
            playerCelebrateNo = Random.Range(0, playerCelebrate.Length);
            playerCelebrate[playerCelebrateNo].Play();
        }
    }
}
