using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("ToadHighway");
    }

    public void OnClickShowMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void OnClickShowTutorial()
    {
        PlayerPrefs.SetInt("Record", 0);
        SceneManager.LoadScene("Tutorial");
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

    public void OnClickShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
