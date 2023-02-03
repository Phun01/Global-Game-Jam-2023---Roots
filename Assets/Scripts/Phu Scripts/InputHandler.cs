using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 inputVector { get; private set; }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        inputVector = new Vector2(hAxis, yAxis);
    }
}
