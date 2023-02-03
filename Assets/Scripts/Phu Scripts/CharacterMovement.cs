using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private InputHandler inputHandler;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(inputHandler.inputVector.x, 0, inputHandler.inputVector.y);

        //Move in vector
        MoveTowards(moveVector);
    }

    //Method to move the character
    private void MoveTowards(Vector3 moveVector)
    {
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }
}
