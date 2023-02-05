using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS.Player;

public class GunBob : MonoBehaviour
{
    [Header("Settings - Time Mode")]
    public bool timeMovement;

    public float timeModeSpeed = 1f;
    public float timePauseTimeSet = 1.5f;
    public float movementTimerSet = 3f;

    [Header("Select Movement - Time Mode")]
    public bool moveUpAndDown;
    public bool moveLeftAndRight;
    public bool moveForwardAndBack;

    [Header("Increase Movement Rate - Time Mode")]
    public float upDownRate = 1f;
    public float leftRightRate = 1f;
    public float forwardBackRate = 1f;

    [Header("Toggel Reverse - Time Mode")]
    public bool reverseUpDown;
    public bool reverseLeftRight;
    public bool reverseForwardAndBack;

    [Header("Dont Adjust!! - viewing only")]
    public float movementTimer;
    public float pauseTimer;

    PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.walking || playerMove.turning)
        {
            if (timeMovement)
            {
                MovingTimerMode();
            }
            else if (!timeMovement)
            {
                PausedTimerMode();
            }
        }
    }

    void MovingTimerMode()
    {
        movementTimer += Time.deltaTime;

        if (moveUpAndDown)
        {
            MovingUpAndDown();
        }
        if (moveForwardAndBack)
        {
            MovingForwardAndBack();
        }
        if (moveLeftAndRight)
        {
            MovingLeftAndRight();
        }

        if (movementTimer >= movementTimerSet)
        {
            pauseTimer = 0;
            timeMovement = false;
        }
    }

    void PausedTimerMode()
    {
        pauseTimer += Time.deltaTime;
        if (pauseTimer >= timePauseTimeSet)
        {
            movementTimer = 0;
            timeMovement = true;
            if (reverseUpDown)
            {
                reverseUpDown = false;
            }
            else if (!reverseUpDown)
            {
                reverseUpDown = true;
            }
            if (reverseForwardAndBack)
            {
                reverseForwardAndBack = false;
            }
            else if (!reverseForwardAndBack)
            {
                reverseForwardAndBack = true;
            }
            if (reverseLeftRight)
            {
                reverseLeftRight = false;
            }
            else if (!reverseLeftRight)
            {
                reverseLeftRight = true;
            }
        }
    }

    void MovingUpAndDown()
    {
        if (reverseUpDown)
        {
            transform.Translate(Vector3.up * timeModeSpeed * upDownRate * Time.deltaTime);
        }
        else if (!reverseUpDown)
        {
            transform.Translate(Vector3.down * timeModeSpeed * upDownRate * Time.deltaTime);
        }
    }

    void MovingLeftAndRight()
    {
        if (reverseLeftRight)
        {
            transform.Translate(Vector3.right * timeModeSpeed * leftRightRate * Time.deltaTime);
        }
        else if (!reverseLeftRight)
        {
            transform.Translate(Vector3.left * timeModeSpeed * leftRightRate * Time.deltaTime);
        }
    }

    void MovingForwardAndBack()
    {
        if (reverseForwardAndBack)
        {
            transform.Translate(Vector3.forward * timeModeSpeed * forwardBackRate * Time.deltaTime);
        }
        else if (!reverseForwardAndBack)
        {
            transform.Translate(Vector3.back * timeModeSpeed * forwardBackRate * Time.deltaTime);
        }
    }
}
