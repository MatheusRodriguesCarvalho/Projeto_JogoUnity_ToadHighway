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
    public void OnClickExitGame()
    {
        Application.Quit();
    }

}
