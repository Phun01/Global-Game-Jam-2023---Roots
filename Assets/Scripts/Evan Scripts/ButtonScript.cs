using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject title;
    public GameObject butts;
    public GameObject hTP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HTP()
    {
        //turn off title, turn off buttons, turn on HTP
        title.SetActive(false);
        butts.SetActive(false);
        hTP.SetActive(true);
    }
    public void BackButton()
    {
        //turn on title, turn on buttons, turn off HTP
        title.SetActive(true);
        butts.SetActive(true);
        hTP.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
