using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public MeshRenderer material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>();
        material.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
