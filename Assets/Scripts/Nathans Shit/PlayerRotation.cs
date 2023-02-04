using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("Turning")]
    public bool turning;
    public float rotateSpeed;
    public float mouseScence;

    [Header("Inputs")]
    public float verticalInput1;
    public float horizontalInput1;

    public PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMove.playerNo <= 1)
        {
            horizontalInput1 = Input.GetAxis("Horizontal1");
            verticalInput1 = Input.GetAxis("Vertical1");
        }

        if (playerMove.playerNo > 1)
        {
            horizontalInput1 = Input.GetAxis("P2Horizontal1");
            verticalInput1 = Input.GetAxis("P2Vertical1");
        }
    }

    private void FixedUpdate()
    {
        Rotation();
    }

    void Rotation()
    {

        if (horizontalInput1 > 0)
        {
            transform.Rotate(new Vector3(0, horizontalInput1, 0) * Time.deltaTime * rotateSpeed);
        }
        if (horizontalInput1 < 0)
        {
            transform.Rotate(new Vector3(0, horizontalInput1, 0) * Time.deltaTime * rotateSpeed);
        }
        /*
        if (playerNo == 1)
        {
            float mousehorizontalInput1 = Input.GetAxis("Mouse X");
            float mouseverticalInput1 = Input.GetAxis("Mouse Y");
            if (mousehorizontalInput1 > 0)
            {
                transform.Rotate(Vector3.up * mouseScence);
            }
            if (mousehorizontalInput1 < 0)
            {
                transform.Rotate(Vector3.up * -mouseScence);
            }
        }*/

    }
}
