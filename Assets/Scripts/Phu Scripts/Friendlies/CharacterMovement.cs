using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    private InputHandler inputHandler;
    public float moveSpeed;

    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 moveVector = new Vector3(inputHandler.inputVector.x, 0, inputHandler.inputVector.y);
        moveVector = new Vector3();

        if(Input.GetKey(KeyCode.W))
        {
            moveVector = transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector = -transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveVector = -transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector = transform.right;
        }

        //Move in vector
        MoveTowards(moveVector);
    }

    //Method to move the character
    private void MoveTowards(Vector3 moveVector)
    {
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }
}
