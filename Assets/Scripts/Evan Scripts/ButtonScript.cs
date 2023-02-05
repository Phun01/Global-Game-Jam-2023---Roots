using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject title;
    public GameObject butts;
    public GameObject hTP;
    public GameObject creds;
    public GameObject fadeOut;
    public AudioSource selectTone;
    public AudioSource gameModeSounds;

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
        SelectSFX();
        title.SetActive(false);
        butts.SetActive(false);
        hTP.SetActive(true);
    }
    public void BackButton()
    {
        //turn on title, turn on buttons, turn off HTP
        SelectSFX();
        title.SetActive(true);
        butts.SetActive(true);
        hTP.SetActive(false);
        
    }

    public void CreditBack()
    {
        //turn on title and butts, turn off cred
        SelectSFX();
        title.SetActive(true);
        butts.SetActive(true);
        creds.SetActive(false);
    }

    public void ToCreds()
    {
        //turn off title and butt, turn on cred
        SelectSFX();
        title.SetActive(false);
        butts.SetActive(false);
        creds.SetActive(true);
    }

    public void QuitButton()
    {
        SelectSFX();
        Application.Quit();
    }

    public void LoadArcade()
    {
        fadeOut.SetActive(true);
        GameMode();
        LoadLevel(1);
    }

    public void LoadRacer()
    {
        fadeOut.SetActive(true);
        GameMode();
        LoadLevel(2);
    }

    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    //scene load
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        yield return new WaitForSeconds(2);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void SelectSFX()
    {
        selectTone.Play();
    }

    public void GameMode()
    {
        gameModeSounds.Play();
    }
}
