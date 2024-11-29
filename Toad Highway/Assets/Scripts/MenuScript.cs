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
    void OnClickStartGame()
    {
        SceneManager.LoadScene("ToadHighway");
    }
    void OnClickExitGame()
    {
        Application.Quit();
    }

}
