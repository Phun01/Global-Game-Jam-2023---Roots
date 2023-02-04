//Evan's Script. Just a basic on if for intro things

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIntro : MonoBehaviour
{
    public float timer = 12f;
    public GameObject text;
    public Animator aniFade;
    public GameObject title;
    public GameObject buttonsStuff;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 7)
        {
            text.SetActive(true);
        }

        if (timer <= 4)
        {
            aniFade.SetTrigger("FadeTrigger");
        }
        if (timer <= 2)
        {
            
            title.SetActive(true);
        }

        if (timer <= 0)
        {
            buttonsStuff.SetActive(true);
        }
    }

}
