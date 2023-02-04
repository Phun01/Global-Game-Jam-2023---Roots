//Evan's Script. Just a basic on if for intro things

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIntro : MonoBehaviour
{
    public float timer = 10f;
    public GameObject text;
    public Animator aniFade;
    public GameObject title;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 5)
        {
            text.SetActive(true);
        }

        if (timer <= 2)
        {
            aniFade.SetTrigger("FadeTrigger");
        }
        if (timer <= 0)
        {
            
            title.SetActive(true);
        }
    }

}
